using DSharpPlus.CommandsNext;
using PhantasyBot.DataAccess.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhantasyBot.Logic
{
    public class MessageLogic
    {
        private readonly Config _config;
        public MessageLogic() => _config = new Config();

        public async Task ClearMessages(CommandContext ctx)
        {
            if(ctx.Channel.Id != _config.Get().Bot.TestChannelId || !_config.IsSudoer(ctx.User.Id))
            {
                await ctx.RespondAsync("You can not use that command here.");
                return;
            }

            var messages = await ctx.Channel.GetMessagesAsync();
            await ctx.Channel.DeleteMessagesAsync(messages);
        }
    }
}
