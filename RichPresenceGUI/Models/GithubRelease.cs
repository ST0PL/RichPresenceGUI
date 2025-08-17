namespace RichPresenceGUI.Models
{
    public class GithubRelease(string? tagName, string? hash, string? downloadUrl)
    {
        public string? TagName => tagName;
        public string? Hash => hash;
        public string? DownloadUrl => downloadUrl;
    }
}
