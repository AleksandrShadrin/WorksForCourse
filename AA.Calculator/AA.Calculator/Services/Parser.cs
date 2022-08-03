using AA.Calculator.CustomExceptions;
using AA.Calculator.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AA.Calculator.Services
{
    public class Parser : IParser
    {
        private readonly Regex _regex;
        private readonly IMapper<char, Operator> mapper;
        public Parser()
        {
            _regex = new(@"(-?\d+[\.Ee]?\d*)\s*([+-\/\*])?");
            mapper = new OperatorsMapper();
        }
        public Expression Parse(string expression)
        {
            var matches = _regex.Matches(expression);



            var op = matches[0].Groups[2].Value;
            var operandL = matches[0].Groups[1].Value;
            var operandR = matches[1].Groups[1].Value;

            if (string.IsNullOrEmpty(op) ||
                string.IsNullOrEmpty(operandL) ||
                string.IsNullOrEmpty(operandR))
                throw new InvalidExpresssionException(expression);

            return new()
            {
                OperandL = float.Parse(operandL, CultureInfo.InvariantCulture),
                OperandR = float.Parse(operandR, CultureInfo.InvariantCulture),
                Operator = mapper.Map(Convert.ToChar(op))
            };
        }
    }
}
