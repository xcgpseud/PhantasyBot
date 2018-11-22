using Newtonsoft.Json;

namespace PhantasyBot.DataAccess.Config.Models
{
    public class ConfigModel
    {
        [JsonProperty("bot")]
        public BotModel Bot { get; set; }
    }
}
