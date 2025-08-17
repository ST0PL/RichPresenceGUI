namespace RichPresenceGUI.Events
{
    class LocaleChangedEvent(string locale) : IEvent<string>
    {
        public string Args => locale;
    }
}
