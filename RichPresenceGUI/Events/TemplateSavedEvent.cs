using RichPresenceGUI.Models;

namespace RichPresenceGUI.Events
{
    class TemplateSavedEvent : TemplateSaveEvent
    {
        public TemplateSavedEvent(Template template) : base(template)
        {
        }
    }
}
