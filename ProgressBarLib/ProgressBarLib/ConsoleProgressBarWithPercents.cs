using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressBarLib
{
    public class ConsoleProgressBarWithPercents : ConsoleProgressBar
    {
        public ConsoleProgressBarWithPercents(int max) : base(max)
        {
        }

        public override void Draw()
        {
            base.Draw();

            Console.SetCursorPosition(Console.WindowWidth / 2 + 10, 0);
            Console.Write($"Loading: {Percent}");
        }
    }
}
