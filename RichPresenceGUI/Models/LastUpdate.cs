namespace RichPresenceGUI.Models
{
    public class LastUpdate(DateTime lastCheck, GithubRelease release)
    {
        public DateTime LastCheck => lastCheck;
        public GithubRelease Release => release;
    }
}
