
using Snowfall;

Random random = new();
int screenWidth = 118;
int screenHeight = 35;
Console.WindowHeight = screenHeight + 15;
Console.WindowWidth = screenWidth + 15;
List<Snowflake> snowflakes = new();

void GenerateSnoflakes()
{
    for (int i = 0; i < screenWidth; i++)
    {
        for (int j = 0; j < screenHeight; j++)
        {
            if (random.NextDouble() > 0.8)
            {
                snowflakes.Add(SnowflakeFactory.Create(i, j, screenWidth, screenHeight));
            }
        }
    }
}
GenerateSnoflakes();
Screen myScreen = new(snowflakes);

while (true)
{
    Thread.Sleep(10);
    myScreen.Render();
}