using System.Text.Json.Serialization;

namespace SteamApps.Model
{
    public class AppNews
    {
        [JsonPropertyName("appid")]
        public string AppId { get; set; }

        [JsonPropertyName("type")]
        public List<NewsItem>? NewsItems { get; set; }
    }

    public class NewsItem
    {
        [JsonPropertyName("gid")]
        public long Gid { get; set; }
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("author")]
        public string? Author { get; set; }

        [JsonPropertyName("contents")]
        public string? Contents { get; set; }

        [JsonPropertyName("feedlabel")]
        public string? Feedlabel { get; set; }

        [JsonPropertyName("date")]
        public long Date { get; set; }

        [JsonPropertyName("tags")]
        public string[]? Tags { get; set; }
    }
}
