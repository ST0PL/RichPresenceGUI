using System.IO;

namespace RichPresenceGUI.Services.Interfaces
{
    public interface ITemplateService<T>
    {
        Task<T> LoadTemplateAsync(string filename);
        Task SaveTemplateAsync(string filename, T templateObj);
        Task SaveTemplateAsync(Stream stream, T templateObj);
        bool DeleteTemplate(string filename);
        IAsyncEnumerable<T> LoadTemplatesAsync(string path);
        bool CheckEquals(T obj1, T obj2);
    }
}