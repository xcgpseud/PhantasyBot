using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using PhantasyBot.DataAccess.Config;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhantasyBot.Logic
{
    public class TestLogic
    {
        private readonly Config _config;
        public TestLogic() => _config = new Config();

        public async Task TestWorking(CommandContext ctx)
        {
            await ctx.RespondAsync("The bot is working.");
        }

        public async Task TestJoin(CommandContext ctx)
        {
            var botChannelMention = ctx.Guild.Channels.First(x => x.Id == _config.Get().Bot.TestChannelId).Mention;

            if (ctx.Member.Roles.Select(x => x.Id).Contains(_config.Get().Bot.TestRoleId))
            {
                await ctx.RespondAsync($"You are already in the bot testing channel: {botChannelMention}");
                return;
            }

            await ctx.Member.GrantRoleAsync(ctx.Guild.GetRole(_config.Get().Bot.TestRoleId));
            await ctx.RespondAsync($"You have been added to the bot testing channel: {botChannelMention}");
        }

        public async Task TestLeave(CommandContext ctx)
        {
            if(!ctx.Member.Roles.Select(x => x.Id).Contains(_config.Get().Bot.TestRoleId))
            {
                await ctx.RespondAsync("You are not in the testing channel. Type `!test join` in order to join.");
                return;
            }

            await ctx.Member.RevokeRoleAsync(ctx.Guild.GetRole(_config.Get().Bot.TestRoleId));
            await ctx.RespondAsync($"Removed {ctx.Member.Mention} from the bot testing channel.");
        }
    }
}
