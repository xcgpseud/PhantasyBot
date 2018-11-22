using DSharpPlus.CommandsNext;
using System.Threading.Tasks;

namespace PhantasyBot.Logic
{
    public class TestLogic
    {
        public async Task TestWorking(CommandContext ctx)
        {
            await ctx.RespondAsync("The bot is working.");
        }
    }
}
