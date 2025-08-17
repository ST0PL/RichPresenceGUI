using RichPresenceGUI.Services.Interfaces;
using System.Collections.Concurrent;
using System.Windows;

namespace RichPresenceGUI.Services
{
    class WindowService : IWindowService
    {
        private ConcurrentDictionary<Guid, Window> _windows = new();

        public Guid Show(Window window)
        {
            if(window != null)
            {
                var guid = Guid.NewGuid();
                _windows.TryAdd(guid, window);
                window.Show();
                window.Unloaded += (_, _) => RemoveWindow(guid);
                return guid;
            }
            throw new ArgumentException("Window cannot be null");
        }
        public Guid Show<T>() where T : Window, new()
        {
            var guid = Guid.NewGuid();
            var window = new T();
            _windows.TryAdd(guid, window);
            window.Show();
            window.Unloaded += (_, _) => RemoveWindow(guid);
            return guid;
        }
        public Guid Show<T>(object dataContext) where T : Window, new()
        {
            var guid = Guid.NewGuid();
            var window = new T() { DataContext = dataContext };
            _windows.TryAdd(guid, window);
            window.Show();
            window.Unloaded += (_, _) => RemoveWindow(guid);
            return guid;
        }
        public bool Close(Guid guid)
        {
            if(RemoveWindow(guid) is { } window)
            {
                window.Close();
                return true;
            }
            return false;
        }
        public Window? RemoveWindow(Guid guid)
        {
            _windows.TryRemove(guid, out var window);
            return window;
        }
    }
}
