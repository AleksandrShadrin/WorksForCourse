using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressBarLib
{
    public sealed class ConsoleProgressBarWithPercents : ConsoleProgressBar
    {
        public ConsoleProgressBarWithPercents(int max, Coords2D posInConsole) : base(max, posInConsole)
        {
        }
        private const string indent = "     ";
        protected override string CreateProgressBar()
        {
            string progressBar = base.CreateProgressBar();
            progressBar += $"{indent}Current Percents: {Percent}%";
            return progressBar;
        }
    }
}
