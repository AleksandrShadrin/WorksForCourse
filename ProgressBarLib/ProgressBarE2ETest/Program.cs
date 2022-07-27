using ProgressBarLib;


AbstractProgressBar bar = new ConsoleProgressBarWithPercents(125, new() { X = 0, Y = Console.CursorTop });

Console.CursorVisible = false;
Console.Clear();


for (int i = 0; i <= 145; i++)
{
    Thread.Sleep(10);
    bar.Draw();
    bar.ShiftCurrentPos(1);
}


Console.CursorVisible = true;
Console.ReadKey();
