using AA.Calculator.CustomExceptions;
using AA.Calculator.Models;
using AA.Calculator.Services.Parser;

namespace AA.Calculator.Services.Calculator
{
    public class Calculator : ICalculator
    {
        private readonly IParser _parser;
        public Calculator(IParser parser)
        {
            _parser = parser == null ? throw new ArgumentNullException(nameof(parser)) : parser;
        }
        public float Calc(string expression)
        {
            try
            {
                var parsedExpression = _parser.Parse(expression);
                return Calc(_parser.Parse(expression));
            }
            catch (InvalidExpresssionException ex)
            {
                throw;
            }
            catch (DivideByZeroException ex)
            {
                throw;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw;
            }
            catch (WrongMappingException ex)
            {
                throw;
            }
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
