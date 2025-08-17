using RichPresenceGUI.Models;


namespace RichPresenceGUI.Events
{
    class TemplateSelectedEvent(Template? template) : IEvent<Template?>
    {
        public Template? Args => template;
    }
}
