namespace RichPresenceGUI.Services.Interfaces
{
    public interface ISettingsService<T>
    {
        Task WriteAsync();
        Task LoadAsync();
        T? GetInstance();
    }
}
