using RichPresenceGUI.Services.Interfaces;


namespace RichPresenceGUI.Services
{
    class EventAggregator : IEventAggregator
    {
        private readonly Dictionary<Type, List<Delegate>> _eventsDict;
        public EventAggregator()
            => _eventsDict = new Dictionary<Type, List<Delegate>>();

        public void Subscribe<TEvent>(Action<TEvent> action)
        {
            if (!_eventsDict.TryGetValue(typeof(TEvent), out _))
                _eventsDict.Add(typeof(TEvent), new());
            _eventsDict[typeof(TEvent)].Add(action);
        }

        public void Unsubscribe<TEvent>(Action<TEvent> action)
        {
            if (_eventsDict.TryGetValue(typeof(TEvent), out var handlers))
            {
                handlers.RemoveAll(c=>c.Equals(action));
                if(handlers?.Count < 1)
                    _eventsDict.Remove(typeof(TEvent));
            }
        }

        public void Publish<TEvent>(TEvent @event)
        {
            if (_eventsDict.TryGetValue(typeof(TEvent), out var handlers))
                handlers.ForEach(h => ((Action<TEvent>)h).Invoke(@event));
        }
    }
}
