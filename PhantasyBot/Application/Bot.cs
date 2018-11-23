using DSharpPlus;
using DSharpPlus.CommandsNext;
using PhantasyBot.Application.Controllers;
using PhantasyBot.Application.Helpers;
using PhantasyBot.DataAccess.Config;
using PhantasyBot.DataAccess.Database.Contexts;
using System.Threading.Tasks;

namespace PhantasyBot.Application
{
    public class Bot
    {
        private DiscordClient _client;
        private CommandsNextModule _commandsModule;
        private readonly Config _config;
        
        public Bot()
        {
            _config = new Config();
            using (var db = new MainContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public async Task Start()
        {
            var helper = new BotHelper();

            var discordConfig = helper.GenerateDiscordConfiguration(_config.Get().Bot.Token);

            _client = new DiscordClient(discordConfig);

            var commandsNextConfig = helper.GenerateCommandsNextConfiguration(
                _client, _config.Get().Bot.CommandPrefix);

            _commandsModule = _client.UseCommandsNext(commandsNextConfig);

            RegisterCommandControllers();
            RegisterEvents();

            await _client.ConnectAsync();
            await Task.Delay(-1);
        }

        #region SetupMethods

        private void RegisterCommandControllers()
        {
            _commandsModule.RegisterCommands<TestController>();
            _commandsModule.RegisterCommands<MessageController>();
        }

        private void RegisterEvents()
        {

        }

        #endregion
    }
}
