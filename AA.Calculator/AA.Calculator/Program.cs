using AA.Calculator.Services;

ICalculator calculator = new Calculator();
string expression;
Console.Write("Input: ");
while ((expression = Console.ReadLine()) != "exit")
{
    try
    {
        var result = calculator.Calc(expression);
        Console.WriteLine(result);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.Write("Input: ");
    }

}


