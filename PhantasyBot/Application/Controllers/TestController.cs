using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using PhantasyBot.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhantasyBot.Application.Controllers
{
    [Group("test")]
    public class TestController : Executor
    {
        private readonly TestLogic _logic;

        public TestController() => _logic = new TestLogic();

        [Command("working")]
        [Aliases("works", "w")]
        public async Task Working(CommandContext ctx)
        {
            await Execute(ctx, async () => await _logic.TestWorking(ctx));
        }

        [Command("join")]
        public async Task Join(CommandContext ctx)
        {
            await Execute(ctx, async () => await _logic.TestJoin(ctx));
        }

        [Command("leave")]
        public async Task Leave(CommandContext ctx)
        {
            await Execute(ctx, async () => await _logic.TestLeave(ctx));
        }
    }
}
