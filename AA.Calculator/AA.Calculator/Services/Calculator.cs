using AA.Calculator.Models;

namespace AA.Calculator.Services
{
    public class Calculator : ICalculator
    {
        private readonly IParser _parser;
        public Calculator()
        {
            _parser = new Parser();
        }
        public float Calc(string expression)
        {
            return Calc(_parser.Parse(expression));
        }

        private float Calc(Expression expression)
        {
            if (expression.OperandR == 0 && expression.Operator == Operator.DIVISION)
                throw new DivideByZeroException($"{expression.ToString()} have division by zero.");

            var result = expression.Operator switch
            {
                Operator.ADDITION => expression.OperandL + expression.OperandR,
                Operator.SUBTRACTION => expression.OperandL - expression.OperandR,
                Operator.MULTIPLICATION => expression.OperandL * expression.OperandR,
                Operator.DIVISION => expression.OperandL / expression.OperandR,
            };

            if (float.IsInfinity(result))
                throw new ArgumentOutOfRangeException(nameof(result),
                        $"Result of expression should be in range ({float.MinValue}, {float.MaxValue}).");

            return result;
        }
    }
}
