using DiscordRPC;

namespace RichPresenceGUI.Events
{
    class ClientCreatedEvent(DiscordRpcClient client) : IEvent<DiscordRpcClient>
    {
        public DiscordRpcClient Args => client;
    }
}
