using DiscordRPC;
using System.IO;
using System.Text.Json.Serialization;


namespace RichPresenceGUI.Models
{
    public record class Template(string? ApplicationId, RichPresence RichPresence)
    {
        public string? FilePath { get; set; }
        [JsonIgnore]
        public string? FileNameWithoutExtension
            => Path.GetFileNameWithoutExtension(FilePath);
    }
}
