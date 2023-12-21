using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamAPI.Models
{
    public class AppDetail
    {
        //[JsonPropertyName("type")]
        //public string Type { get; set; }

        //[JsonPropertyName("name")]
        //public string Name { get; set; }

        //[JsonPropertyName("steam_appid")]
        //public int SteamAppId { get; set; }

        //[JsonPropertyName("required_age")]
        //public int RequiredAge { get; set; }

        //[JsonPropertyName("is_free")]
        //public bool IsFree { get; set; }

        //[JsonPropertyName("detailed_description")]
        //public string DetailedDescription { get; set; }

        //[JsonPropertyName("about_the_game")]
        //public string AboutTheGame { get; set; }

        [JsonPropertyName("short_description")]
        public string ShortDescription { get; set; }

        //[JsonPropertyName("supported_languages")]
        //public string SupportedLanguages { get; set; }

        //[JsonPropertyName("header_image")]
        //public string HeaderImage { get; set; }

        [JsonPropertyName("capsule_image")]
        public string CapsuleImage { get; set; }

        //[JsonPropertyName("capsule_imagev5")]
        //public string CapsuleImageV5 { get; set; }

        //[JsonPropertyName("website")]
        //public string Website { get; set; }

        //[JsonPropertyName("pc_requirements")]
        //public PcRequirements? PcRequirements { get; set; }

        //[JsonPropertyName("mac_requirements")]
        //public MacRequirements? MacRequirements { get; set; }

        //[JsonPropertyName("linux_requirements")]
        //public LinuxRequirements? LinuxRequirements { get; set; }

        //[JsonPropertyName("developers")]
        //public List<string> Developers { get; set; }

        //[JsonPropertyName("publishers")]
        //public List<string> Publishers { get; set; }

        //[JsonPropertyName("price_overview")]
        //public PriceOverview? PriceOverview { get; set; }

        //[JsonPropertyName("packages")]
        //public List<int> Packages { get; set; }

        //[JsonPropertyName("package_groups")]
        //public List<PackageGroup>? PackageGroups { get; set; }

        //[JsonPropertyName("platforms")]
        //public Platforms? Platforms { get; set; }

        [JsonPropertyName("metacritic")]
        public Metacritic? Metacritic { get; set; }

        //[JsonPropertyName("categories")]
        //public List<Category>? Categories { get; set; }

        //[JsonPropertyName("genres")]
        //public List<Genre>? Genres { get; set; }

        //[JsonPropertyName("screenshots")]
        //public List<Screenshot> Screenshots { get; set; }

        //[JsonPropertyName("recommendations")]
        //public Recommendations Recommendations { get; set; }

        //[JsonPropertyName("release_date")]
        //public ReleaseDate ReleaseDate { get; set; }

        //[JsonPropertyName("support_info")]
        //public SupportInfo SupportInfo { get; set; }

        //[JsonPropertyName("background")]
        //public string Background { get; set; }

        //[JsonPropertyName("background_raw")]
        //public string BackgroundRaw { get; set; }

        //[JsonPropertyName("content_descriptors")]
        //public ContentDescriptors ContentDescriptors { get; set; }
    }

    public class PcRequirements
    {
        [JsonPropertyName("minimum")]
        public string Minimum { get; set; }
    }

    public class MacRequirements
    {
        [JsonPropertyName("minimum")]
        public string Minimum { get; set; }
    }

    public class LinuxRequirements
    {
        [JsonPropertyName("minimum")]
        public string? Minimum { get; set; }
    }

    public class PriceOverview
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("initial")]
        public int Initial { get; set; }

        [JsonPropertyName("final")]
        public int Final { get; set; }

        [JsonPropertyName("discount_percent")]
        public int DiscountPercent { get; set; }

        [JsonPropertyName("initial_formatted")]
        public string InitialFormatted { get; set; }

        [JsonPropertyName("final_formatted")]
        public string FinalFormatted { get; set; }
    }

    public class PackageGroup
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("selection_text")]
        public string SelectionText { get; set; }

        [JsonPropertyName("save_text")]
        public string SaveText { get; set; }

        [JsonPropertyName("display_type")]
        public int DisplayType { get; set; }

        [JsonPropertyName("is_recurring_subscription")]
        public string IsRecurringSubscription { get; set; }

        [JsonPropertyName("subs")]
        public List<Sub> Subs { get; set; }
    }

    public class Sub
    {
        [JsonPropertyName("packageid")]
        public int PackageId { get; set; }

        [JsonPropertyName("percent_savings_text")]
        public string PercentSavingsText { get; set; }

        [JsonPropertyName("percent_savings")]
        public int PercentSavings { get; set; }

        [JsonPropertyName("option_text")]
        public string OptionText { get; set; }

        [JsonPropertyName("option_description")]
        public string OptionDescription { get; set; }

        [JsonPropertyName("can_get_free_license")]
        public string CanGetFreeLicense { get; set; }

        [JsonPropertyName("is_free_license")]
        public bool IsFreeLicense { get; set; }

        [JsonPropertyName("price_in_cents_with_discount")]
        public int PriceInCentsWithDiscount { get; set; }
    }

    public class Platforms
    {
        [JsonPropertyName("windows")]
        public bool Windows { get; set; }

        [JsonPropertyName("mac")]
        public bool Mac { get; set; }

        [JsonPropertyName("linux")]
        public bool Linux { get; set; }
    }

    public class Metacritic
    {
        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Category
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class Genre
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class Screenshot
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("path_thumbnail")]
        public string PathThumbnail { get; set; }

        [JsonPropertyName("path_full")]
        public string PathFull { get; set; }
    }

    public class Recommendations
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

    public class ReleaseDate
    {
        [JsonPropertyName("coming_soon")]
        public bool ComingSoon { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }
    }

    public class SupportInfo
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    public class ContentDescriptors
    {
        [JsonPropertyName("ids")]
        public List<int> Ids { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }
    }
}
