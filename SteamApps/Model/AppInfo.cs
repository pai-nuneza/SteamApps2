namespace SteamApps.Model
{
    public class AppInfo
    {
        public int AppId { get; set; }
        public string Name { get; set; }
        public long LastModified { get; set; }
        public int PriceChangeNumber { get; set; }
        public string CapsuleImage { get; set; }
        public string ShortDescription { get; set; }
    }
}
