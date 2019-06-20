using DiscordRPC;
using DiscordRPC.Logging;
using System;

namespace EasyPresence.Lib
{
    public class Discord
    {
        private DiscordRpcClient DiscordRpcClient { get; }
        private bool IsUp { get; set; }

        public Discord(string id)
        {
            DiscordRpcClient = new DiscordRpcClient(id) {Logger = new ConsoleLogger {Level = LogLevel.Warning}};
            DiscordRpcClient.OnReady += (sender, e) =>
            {
                Console.WriteLine(@"Received Ready from user {0}", e.User.Username);
            };

            DiscordRpcClient.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine(@"Received Update! {0}", e.Presence);
            };
        }

        public void Initialize()
        {
            IsUp = DiscordRpcClient.Initialize();
        }

        public void SetPresence(RichPresence richPresence)
        {
            if (!IsUp) return;
            DiscordRpcClient.SetPresence(richPresence);
        }

        public void Invoke()
        {
            if (!IsUp) return;
            DiscordRpcClient.Invoke();
        }
        
        public void Reset()
        {
            DiscordRpcClient.Deinitialize();
        }
    }
}