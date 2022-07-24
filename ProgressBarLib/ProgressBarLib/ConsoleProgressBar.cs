using System.Diagnostics;

namespace ProgressBarLib
{
    public class ConsoleProgressBar : AbstractProgressBar
    {
        private bool _initialized = false;
        private bool _needToResize = false;
        private int _consoleWidth = Console.WindowWidth;

        public ConsoleProgressBar(int max) : base(max)
        {
        }

        private void ClearLine()
        {
            Console.SetCursorPosition(0, 0);
            Console.Clear();
        }

        private string CreateDefaultProgress()
            => new String(' ', _consoleWidth / 2);

        private void Resize()
        {
            ClearLine();
            Console.SetCursorPosition(0, 0);
            Console.Write($"[{CreateDefaultProgress()}]");
            Draw();
        }

        public override void Draw()
        {
            _needToResize = _consoleWidth != Console.WindowWidth;
            _consoleWidth = Console.BufferWidth;

            if (_needToResize)
            {
                Resize();
                _needToResize = false;
            }

            if (_initialized == false)
            {
                Console.Clear();
                Console.Write($"[{CreateDefaultProgress()}]");
                _initialized = true;
            }
            for (int i = 1; i <= Math.Round((int)(_consoleWidth / 2) * (Percent / 100.0)); i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write('▒');
            }
        }
    }
}
