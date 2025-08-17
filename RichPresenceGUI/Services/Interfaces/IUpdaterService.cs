using RichPresenceGUI.Models;
namespace RichPresenceGUI.Services.Interfaces
{
    public interface IUpdaterService
    {
        Task<LastUpdate?> GetLastUpdateAsync();
        Task<GithubRelease?> GetLatestAsync();
        Task WriteLastUpdateAsync(GithubRelease release);
        string GetProductVersion();
    }
}
