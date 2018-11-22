using Newtonsoft.Json;
using System.Collections.Generic;

namespace PhantasyBot.DataAccess.Config.Models
{
    public class BotModel
    {
        [JsonProperty("test-channel-id")]
        public ulong TestChannelId { get; set; }

        [JsonProperty("test-role-id")]
        public ulong TestRoleId { get; set; }

        [JsonProperty("command-prefix")]
        public string CommandPrefix { get; set; }

        [JsonProperty("sudoers")]
        public List<ulong> Sudoers { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("bot-role-id")]
        public ulong BotRoleId { get; set; }
    }
}
