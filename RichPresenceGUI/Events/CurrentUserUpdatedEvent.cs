using DiscordRPC;

namespace RichPresenceGUI.Events
{
    class CurrentUserUpdatedEvent(User? user) : IEvent<User?>
    {
        public User? Args => user;
    }
}
