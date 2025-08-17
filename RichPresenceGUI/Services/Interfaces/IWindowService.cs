using System.Windows;

namespace RichPresenceGUI.Services.Interfaces
{
    public interface IWindowService
    {
        public Guid Show(Window window);
        public Guid Show<T>(object dataContext) where T: Window, new();
        public bool Close(Guid guid);
    }
}
