using DSharpPlus.CommandsNext;
using PhantasyBot.DataAccess.Database.Contexts;
using PhantasyBot.DataAccess.Database.Entities;
using System;
using System.Threading.Tasks;

namespace PhantasyBot.Application
{
    public class Executor
    {
        protected async Task Execute(CommandContext ctx, Func<Task> func)
        {
            try
            {
                LogCommand(ctx);
                await func();
            }
            catch(Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }

        private void LogCommand(CommandContext ctx)
        {
            var commandName = ctx.Command.QualifiedName;
            var commandParams = ctx.RawArgumentString;
            var commandUserId = ctx.User.Id;
            var commandUserDisplayName = ctx.Member.DisplayName;
            var commandTimestamp = DateTime.UtcNow;

            var entity = new CommandLogEntity
            {
                CommandName = commandName,
                CommandParams = commandParams,
                UserId = commandUserId,
                UserDisplayName = commandUserDisplayName,
                CommandTimestamp = commandTimestamp
            };

            using (var db = new MainContext())
            {
                db.CommandLogs.Add(entity);
                db.SaveChanges();
            }
        }
    }
}
