using DSharpPlus;
using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhantasyBot.Application.Helpers
{
    public class BotHelper
    {
        public DiscordConfiguration GenerateDiscordConfiguration(string token)
        {
            return new DiscordConfiguration
            {
                Token = token,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            };
        }

        public CommandsNextConfiguration GenerateCommandsNextConfiguration(DiscordClient client, string stringPrefix)
        {
            var dependencyCollection = new DependencyCollectionBuilder()
                .AddInstance(client)
                .Build();

            return new CommandsNextConfiguration
            {
                StringPrefix = stringPrefix,
                Dependencies = dependencyCollection
            };
        }
    }
}
