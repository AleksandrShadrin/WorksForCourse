using ProgressBarLib;


AbstractProgressBar bar = new ConsoleProgressBarWithPercents(85);
Console.CursorVisible = false;

for (int i = 0; i <= 85; i++)
{
    Thread.Sleep(10);
    bar.Draw();
    bar.ShiftCurrentPos(1);

}

Console.CursorVisible = true;
Console.ReadKey();
