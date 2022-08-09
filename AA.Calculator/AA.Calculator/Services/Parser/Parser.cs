using AA.Calculator.CustomExceptions;
using AA.Calculator.Models;
using AA.Calculator.Services.Mapper;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AA.Calculator.Services.Parser
{
    public class Parser : IParser
    {
        private readonly Regex _regex;
        private readonly IMapper<char, Operator> _mapper;
        public Parser(IMapper<char, Operator> mapper)
        {
            _regex = new(@"([-+]?\d+(?:[Ee]{1}\-?\d+|\.\d+|))\s*([-+\/\*])?");
            _mapper = mapper == null ? throw new ArgumentNullException(nameof(mapper)) : mapper;
        }
        public Expression Parse(string expression)
        {
            var matches = _regex.Matches(expression);

            if (matches.Count == 2)
            {
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
                    Operator = _mapper.Map(Convert.ToChar(op))
                };
            }

            throw new InvalidExpresssionException(expression);
        }
    }
}
