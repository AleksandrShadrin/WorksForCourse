namespace AA.Calculator.Services.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm")}]: {message}");
        }
    }
}
