namespace RichPresenceGUI.Events
{
    interface IEvent<T>
    {
        public T Args { get; }
    }
}
