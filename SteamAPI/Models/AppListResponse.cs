using System.Text.Json.Serialization;

namespace SteamAPI.Models
{
    public class ApiResponse
    {
        public AppListResponse Response { get; set; }
    }

    public class AppListResponse
    {
        public List<App> Apps { get; set; }
    }

    public class App
    {
        [JsonPropertyName("appid")] 
        public int AppId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("last_modified")]
        public long LastModified { get; set; }

        [JsonPropertyName("price_change_number")]
        public int PriceChangeNumber { get; set; }

        public string CapsuleImage { get; set; }

        public string ShortDescription { get; set; }
    }
}
