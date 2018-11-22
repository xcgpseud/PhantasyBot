using System;
using System.Threading.Tasks;

namespace PhantasyBot.Application
{
    public class Executor
    {
        protected async Task Execute(Func<Task> func)
        {
            try
            {
                await func();
            }
            catch(Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }
    }
}
