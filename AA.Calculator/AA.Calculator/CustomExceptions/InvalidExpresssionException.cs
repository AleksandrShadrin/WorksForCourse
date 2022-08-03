namespace AA.Calculator.CustomExceptions
{
    public class InvalidExpresssionException : Exception
    {
        public InvalidExpresssionException(string expression) : base($"expression: {expression} is invalid.")
        { }
    }
}
