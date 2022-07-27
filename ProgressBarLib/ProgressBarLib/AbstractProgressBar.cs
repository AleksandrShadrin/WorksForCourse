namespace ProgressBarLib
{
    abstract public class AbstractProgressBar
    {
        public int Max { get; set; }
        public int CurrentPos { get; set; } = 0;
        public int Percent =>
            Math.Min((int)(Math.Round(100 * CurrentPos / (double)Max)), 100);

        public AbstractProgressBar(int max)
        {
            Max = max;
        }
        public void ShiftCurrentPos(int value)
        {
            CurrentPos += value;
        }
        abstract public void Draw();
    }
}
