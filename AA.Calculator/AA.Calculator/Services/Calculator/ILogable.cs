using AA.Calculator.Services.Logger;

namespace AA.Calculator.Services.Calculator
{
    public interface ILogable
    {
        void RegisterLogger(ILogger logger);
    }
}
