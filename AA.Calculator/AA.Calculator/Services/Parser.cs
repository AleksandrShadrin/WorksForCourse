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
            _regex = new(@"\d+[\.Ee]?\d*");
            mapper = new OperatorsMapper();
        }
        public Expression Parse(string expression)
        {
            var operands = _regex.
                                            Matches(expression).
                                            Select((match) => match.Value).
                                            ToList();

            var strWithoutOperands = _regex.Replace(expression, "").Trim();

            if (string.IsNullOrEmpty(strWithoutOperands) || strWithoutOperands.Length > 1 || operands.Count() != 2)
                throw new InvalidExpresssionException(expression);

            return new()
            {
                OperandL = float.Parse(operands[0], CultureInfo.InvariantCulture),
                OperandR = float.Parse(operands[1], CultureInfo.InvariantCulture),
                Operator = mapper.Map(Convert.ToChar(strWithoutOperands))
            };
        }
    }
}
