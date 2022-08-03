namespace AA.Calculator.CustomExceptions
{
    public class WrongMappingException : Exception
    {
        public WrongMappingException(char wrongOperator) : base($"Operator {wrongOperator} is not supported by this calculator.")
        { }

    }
}
