
using Snowfall;

Random random = new();
int screenWidth = 118;
int screenHeight = 35;
List<Snowflake> snowflakes = new();

// Console settings
Console.WindowHeight = screenHeight + 3;
Console.WindowWidth = screenWidth + 3;
Console.CursorVisible = false;


void GenerateSnoflakes()
{
    for (int i = 0; i < screenWidth; i++)
    {
        for (int j = 0; j < screenHeight; j++)
        {
            if (random.NextDouble() > 0.9)
            {
                snowflakes.Add(SnowflakeFactory.Create(i, j, screenWidth, screenHeight));
            }
        }
    }
}
GenerateSnoflakes();
Screen myScreen = new(snowflakes);


while (!Console.KeyAvailable)
{
    Thread.Sleep(5);
    myScreen.Render();
}
Console.Clear();
