using AA.Calculator.CustomExceptions;
using AA.Calculator.Services.Logger;

namespace AA.Calculator.Services.Calculator
{
    public class LogableCalculator : ILogableCalculator
    {
        private readonly ICalculator _calculator;
        private Action<string> logExceptions;
        public LogableCalculator(ICalculator calculator)
        {
            _calculator = calculator == null ? throw new ArgumentNullException(nameof(_calculator)) : calculator;
        }
        public void RegisterLogger(ILogger logger)
        {
            logExceptions += logger.Log;
        }
        public float Calc(string expression)
        {
            try
            {
                return _calculator.Calc(expression);
            }
            catch (InvalidExpresssionException ex)
            {
                logExceptions?.Invoke(ex.Message);
                throw;
            }
            catch (DivideByZeroException ex)
            {
                logExceptions?.Invoke(ex.Message);
                throw;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                logExceptions?.Invoke(ex.Message);
                throw;
            }
            catch (WrongMappingException ex)
            {
                logExceptions?.Invoke(ex.Message);
                throw;
            }
        }
    }
}
