using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SteamAPI.Models;
using System.Text.Json;

namespace SteamAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class SteamPoweredController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public SteamPoweredController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet("getAppList")]
        public async Task<IActionResult> GetAppList(int page = 1, int pageSize = 10)
        {
            try
            {
                var apiKey = _configuration["AppSettings:SteamApiKey"];
                var apiUrl = $"https://api.steampowered.com/IStoreService/GetAppList/v1?key={apiKey}";

                using var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.GetStringAsync(apiUrl);

                var responseObject = JsonSerializer.Deserialize<ApiResponse>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var allApps = responseObject?.Response?.Apps;

                if (allApps != null)
                {
                    var startIndex = (page - 1) * pageSize;
                    var paginatedApps = allApps.Skip(startIndex).Take(pageSize).ToList();

                    foreach (var app in paginatedApps)
                    {
                        var appDetailResponse = await GetAppDetail(app.AppId);

                        if (appDetailResponse is OkObjectResult okObjectResult)
                        {
                            var appDetailContent = okObjectResult.Value?.ToString();

                            // Deserialize the JSON string into AppDetail
                            var appDetail = JsonSerializer.Deserialize<AppDetail>(appDetailContent, new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });

                            // Add detailed information to the app
                            app.CapsuleImage = appDetail?.CapsuleImage ?? string.Empty;
                            app.ShortDescription = appDetail?.ShortDescription ?? string.Empty;
                        }
                    }

                    return Ok(paginatedApps);
                }

                return Ok(null);

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("getAppDetail")]
        public async Task<IActionResult> GetAppDetail(int appid)
        {
            try
            {
                var apiUrl = $"https://store.steampowered.com/api/appdetails?appids={appid}";

                using var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.GetStringAsync(apiUrl);
                var detail = new object();

                using JsonDocument document = JsonDocument.Parse(response);
                if (document.RootElement.TryGetProperty(appid.ToString(), out JsonElement appElement))
                {
                    var dataElement = appElement.GetProperty("data");
                    if (dataElement.ValueKind != JsonValueKind.Null)
                    {
                        detail = dataElement.GetRawText();
                    }
                    else
                    {
                        Console.WriteLine($"Data for AppId {appid} is null in the response.");
                    }
                }

                if (detail != null)
                {
                    return Ok(detail);
                }

                return Ok(null);

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("getAppNews")]
        public async Task<IActionResult> GetAppNews(int appid)
        {
            try
            {
                var apiUrl = $"https://api.steampowered.com/ISteamNews/GetNewsForApp/v2?appid={appid}";

                using var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.GetStringAsync(apiUrl);
                var detail = new object();

                using JsonDocument document = JsonDocument.Parse(response);
                if (document.RootElement.TryGetProperty("appnews", out JsonElement appElement))
                {
                    var dataElement = appElement.GetProperty("newsitems");
                    if (dataElement.ValueKind != JsonValueKind.Null)
                    {
                        detail = dataElement.GetRawText();
                    }
                    else
                    {
                        Console.WriteLine($"Data for AppId {appid} is null in the response.");
                    }
                }

                if (detail != null)
                {
                    return Ok(detail);
                }

                return Ok(null);

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }

}
