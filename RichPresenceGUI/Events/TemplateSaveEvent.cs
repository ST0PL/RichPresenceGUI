using RichPresenceGUI.Models;
namespace RichPresenceGUI.Events
{
    class TemplateSaveEvent(Template template) : IEvent<Template>
    {
        private Template? _args;
        public Template Args => _args ??= template;
    }
}
