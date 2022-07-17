﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Snowfall
{
    public class Snowflake : IRenderable
    {
        public char SnoflakeSymbol { get; set; } = '*';
        public Vector2 ScreenSize;
        public Vector2 PosOnScreen;
        private float weight;
        private Vector2? prevPosOnScreen;
        Random random = new();

        public void Render()
        {
            if (prevPosOnScreen is { }
                && ((int)Math.Round(prevPosOnScreen.Value.X) != (int)Math.Round(PosOnScreen.X)
                || (int)Math.Round(prevPosOnScreen.Value.Y) != (int)Math.Round(PosOnScreen.Y)))
            {
                Console.SetCursorPosition((int)Math.Round(prevPosOnScreen.Value.X), (int)Math.Round(prevPosOnScreen.Value.Y));
                Console.Write(' ');
            }
            Console.SetCursorPosition((int)Math.Round(PosOnScreen.X), (int)Math.Round(PosOnScreen.Y));
            Console.Write(SnoflakeSymbol);
            prevPosOnScreen = PosOnScreen;
            DisplaceSnoflake();
        }
        private void DisplaceSnoflake()
        {
            float displaceFactor = random.NextDouble() > 0.5 ? 0.1f : -0.1f;
            if (weight == 0)
                weight = (float)(random.NextDouble() + 0.1);

            PosOnScreen.Y += weight;

            if (PosOnScreen.X + displaceFactor > ScreenSize.X)
            {
                PosOnScreen.X = PosOnScreen.X + displaceFactor - ScreenSize.X;
            }
            else if (PosOnScreen.X + displaceFactor < 0)
            {
                PosOnScreen.X = ScreenSize.X - 1;
            }
            else
            {
                PosOnScreen.X += displaceFactor;
            }

            if (PosOnScreen.Y > ScreenSize.Y)
            {
                PosOnScreen.Y = 0;
            }
        }
    }
}
