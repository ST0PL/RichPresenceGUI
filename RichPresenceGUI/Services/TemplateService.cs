using System.IO;
using RichPresenceGUI.Services.Interfaces;
using RichPresenceGUI.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Reflection;
using System.Diagnostics;

namespace RichPresenceGUI.Services
{
    internal class TemplateService : ITemplateService<Template>
    {
        private static readonly JsonSerializerOptions SerializerOptions = new() { UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow };
        private static readonly PropertyInfo[] Properties = typeof(Template).GetProperties();

        public async Task SaveTemplateAsync(string filename, Template template)
        {
            using FileStream fs = new FileStream(filename, FileMode.Create);
            await JsonSerializer.SerializeAsync(fs, template);
        }

        public async Task SaveTemplateAsync(Stream stream, Template template)
            => await JsonSerializer.SerializeAsync(stream, template);

        public async Task<Template> LoadTemplateAsync(string filename)
        {
            if (File.Exists(filename))
            {
                using FileStream fs = new FileStream(filename, FileMode.Open);
                return await JsonSerializer.DeserializeAsync<Template>(fs, SerializerOptions) ?? throw new NullReferenceException();
            }
            throw new FileNotFoundException();
        }
        public async IAsyncEnumerable<Template> LoadTemplatesAsync(string path)
        {
            if (Directory.Exists(path))
            {
                IEnumerable<string> filePaths = Directory.GetFiles(path).Where(p=>p.EndsWith(".json"));
                foreach (var filePath in filePaths)
                {
                    Template? deserialized = null;
                    try
                    {
                        deserialized = await LoadTemplateAsync(filePath);
                        deserialized.FilePath = filePath;
                    }
                    catch(Exception ex) { Debug.WriteLine(ex); continue; }
                    yield return deserialized;
                }
            }
            else
                yield break;
        }
        public bool DeleteTemplate (string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                    return true;
                }
                catch { }
            }
            return false;
        }
        public bool CheckEquals(Template t1, Template t2)
        {
            foreach(var prop in Properties)
            {
                if (prop.GetValue(t1) != prop.GetValue(t2))
                    return false;
            }
            return true;
        }
    }
}
