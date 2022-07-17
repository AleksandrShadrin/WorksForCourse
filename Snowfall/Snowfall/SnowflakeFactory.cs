using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowfall
{
    public static class SnowflakeFactory
    {
        public static Snowflake Create(int posX, int posY, int screenWidth, int screenHeight)
        {
            return new Snowflake { PosOnScreen = new(posX, posY), ScreenSize = new(screenWidth, screenHeight) };
        }
    }
}
