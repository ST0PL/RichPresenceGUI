using RichPresenceGUI.Services.Interfaces;
using RichPresenceGUI.Models;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Security.Cryptography;
using System.Text;

namespace RichPresenceGUI.Services
{
    public class UpdaterService : IUpdaterService
    {

        private readonly string _url;
        private const string FileName = "updates.json";
        private readonly HttpClient _httpClient = new HttpClient();

        public UpdaterService(string owner, string name)
        {
            _url = string.Format(
                "https://api.github.com/repos/{0}/{1}/releases/latest",
                owner, name);
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Updater");
        }

        public string GetProductVersion()
            => Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? string.Empty;

        public string GetAssemblyHash()
        {
            using var fs = new FileStream(Assembly.GetEntryAssembly().Location, FileMode.Open);
            using SHA256 sha256 = SHA256.Create();
            return BitConverter.ToString(sha256.ComputeHash(fs)).Replace("-", "").ToLowerInvariant();
        }
        public async Task<GithubRelease?> GetLatestAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_url);
                using var content = await response.Content.ReadAsStreamAsync();
                var json = await JsonNode.ParseAsync(content);
                string? tagName = json?["tag_name"]?.GetValue<string>();
                string? hash = json?["assets"]?[0]?["digest"]?.GetValue<string>()?.Split("sha256:")[1];
                string? downloadUrl = json?["assets"]?[0]?["browser_download_url"]?.GetValue<string>();
                return new GithubRelease(tagName, hash, downloadUrl);
            }
            catch(Exception ex) when(ex is HttpRequestException or JsonException) { }
            return null;
        }
        public async Task<LastUpdate?> GetLastUpdateAsync()
        {
            LastUpdate? lastUpdate = null;
            if (File.Exists(FileName))
            {
                using var fs = new FileStream(FileName, FileMode.Open);
                lastUpdate = await JsonSerializer.DeserializeAsync<LastUpdate>(fs);
            }
            return lastUpdate;
        }
        public async Task WriteLastUpdateAsync(GithubRelease release)
        {
            using var fs = new FileStream(FileName, FileMode.Create);
            await JsonSerializer.SerializeAsync(fs, new LastUpdate(DateTime.UtcNow, release));
        }
    }
}
