using AA.Calculator.Models;

namespace AA.Calculator.Services.Parser
{
    public interface IParser
    {
        public Expression Parse(string expression);
    }
}
