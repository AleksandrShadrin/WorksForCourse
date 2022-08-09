using AA.Calculator.Models;
using AA.Calculator.Services.Calculator;
using AA.Calculator.Services.Logger;
using AA.Calculator.Services.Mapper;
using AA.Calculator.Services.Parser;

IMapper<char, Operator> mapper = new OperatorsMapper();
IParser parser = new Parser(mapper);
ILogger logger = new ConsoleLogger();
ICalculator calculator = new Calculator(parser);
ILogableCalculator logableCalculator = new LogableCalculator(calculator);
logableCalculator.RegisterLogger(logger);

string expression;
Console.Write("Input: ");
while ((expression = Console.ReadLine()) != "exit")
{
    try
    {
        var result = logableCalculator.Calc(expression);
        Console.WriteLine(result);
    }
    catch (Exception ex)
    {
    }
    finally
    {
        Console.Write("Input: ");
    }

}


