using System.Diagnostics;

namespace ProgressBarLib
{
    public class ConsoleProgressBar : AbstractProgressBar
    {
        public Coords2D PosInConsole { get; set; }
        private bool _needToResize = false;
        private int _consoleWidth = Console.WindowWidth;
        private int _previousBarLength;
        public ConsoleProgressBar(int max, Coords2D posInConsole) : base(max)
        {
            PosInConsole = posInConsole;
        }

        private void ClearLine()
        {
            if (Console.WindowWidth - PosInConsole.X - _previousBarLength < 0)
            {
                Console.SetCursorPosition(PosInConsole.X, Console.CursorTop - 1);
            }
            else
            {
                Console.SetCursorPosition(PosInConsole.X, Console.CursorTop);
            }

            Console.Write(new String(' ', _previousBarLength));
        }

        private int NumberOfCompletedProgressCells
            => Convert.ToInt32(Math.Round((Percent * _consoleWidth / 2) / 100.0));
        protected virtual string CreateProgressBar()
            => $"[{new string('▒', NumberOfCompletedProgressCells)}" +
                $"{new string(' ', Math.Max(_consoleWidth / 2 - NumberOfCompletedProgressCells, 0))}]";

        private void Resize()
        {
            ClearLine();
            Draw();
        }

        public override void Draw()
        {
            _needToResize = _consoleWidth != Console.WindowWidth;
            _consoleWidth = Console.WindowWidth;

            if (_needToResize)
            {
                Resize();
                _needToResize = false;
                return;
            }

            string progressBar = CreateProgressBar();
            _previousBarLength = progressBar.Length;

            Console.SetCursorPosition(PosInConsole.X, PosInConsole.Y);
            Console.Write(progressBar);
        }
    }
}
