using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace RichPresenceGUI.ViewModels
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        
        public void OnPropertyChanged([CallerMemberName] string? property = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        
        public void OnPropertiesChanged(params string[] properties)
        {
            if (properties is null or { Length : <1 })
                throw new ArgumentNullException("properties must have at least 1 element");

            foreach(string property in properties)
                OnPropertyChanged(property);
        }
    }
}
