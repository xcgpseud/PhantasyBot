using PhantasyBot.Application;

namespace PhantasyBot
{
    public class Program
    {
        static void Main()
        {
            var bot = new Bot();
            bot.Start().ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
