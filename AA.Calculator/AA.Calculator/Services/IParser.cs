using AA.Calculator.Models;

namespace AA.Calculator.Services
{
    public interface IParser
    {
        public Expression Parse(string expression);
    }
}
