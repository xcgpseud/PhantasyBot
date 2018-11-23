using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using PhantasyBot.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhantasyBot.Application.Controllers
{
    [Group("messages")]
    [Aliases("m")]
    public class MessageController : Executor
    {
        private MessageLogic _logic;
        public MessageController() => _logic = new MessageLogic();

        [Command("clear")]
        [Aliases("c")]
        public async Task ClearMessages(CommandContext ctx)
        {
            await Execute(ctx, async () => await _logic.ClearMessages(ctx));
        }
    }
}
