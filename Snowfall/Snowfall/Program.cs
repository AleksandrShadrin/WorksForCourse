
using Snowfall;

Random random = new();

// Screen settings
int screenWidth = 118;
int screenHeight = 35;

// Console settings
Console.WindowHeight = screenHeight + 3;
Console.WindowWidth = screenWidth + 3;
Console.CursorVisible = false;

IRenderable screen = new Screen();

void GenerateSnoflakes()
{
    for (int i = 0; i < screenWidth; i++)
    {
        for (int j = 0; j < screenHeight; j++)
        {
            if (random.NextDouble() > 0.9)
            {
                screen.AddIRenderable(SnowflakeFactory.Create(i, j, screenWidth, screenHeight));
            }
        }
    }
}

GenerateSnoflakes();

while (!Console.KeyAvailable)
{
    Thread.Sleep(5);
    screen.Render();
}
Console.Clear();
