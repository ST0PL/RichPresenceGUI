namespace RichPresenceGUI.Services.Interfaces
{
    public interface IEventAggregator 
    {
        public void Subscribe<TEvent>(Action<TEvent> method);
        public void Unsubscribe<TEvent>(Action<TEvent> method);
        public void Publish<TEvent>(TEvent @event);
    }
}
