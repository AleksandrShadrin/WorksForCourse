using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
