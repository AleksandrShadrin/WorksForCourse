namespace ProgressBarLib
{
    abstract public class AbstractProgressBar
    {
        public int Max { get; set; }
        public int CurrentPos { get; set; } = 0;
        public int Percent =>
            Math.Min((int)(Math.Round(100 * CurrentPos / (double)Max)), 100);
        public Coords2D PosInConsole { get; set; }
        public AbstractProgressBar(int max, Coords2D posInConsole)
        {
            Max = max;
            PosInConsole = posInConsole;
        }
        public void ShiftCurrentPos(int value)
        {
            CurrentPos += value;
        }
        abstract public void Draw();
    }
}
