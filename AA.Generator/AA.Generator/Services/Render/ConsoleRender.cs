namespace AA.Generator.Services.Render
{
    public class ConsoleRender : IRender
    {
        public void Render(string text)
        {
            Console.WriteLine(text);
        }
    }
}
