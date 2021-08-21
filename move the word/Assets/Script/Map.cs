using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script
{
    public class Map
    {
        public static readonly int Width = 100;
        public static readonly int Height = 100;

        private char[,] NewMap = new char[Map.Width, Map.Height];

        public char[,] Generate()
        {
            var rand = new Random();

            for (int i = 0; i < Map.Width / 2 * 3; i++)
            {
                int x = rand.Next(0, Map.Width - 1);
                int y = rand.Next(0, Map.Height - 1);
                for (int j = 0; j < Map.Width / 5; j++)
                {
                    NewMap[x, y] = '#';
                    int select = rand.Next(1, 100);
                    if (select > 50)
                        x += rand.Next(-1, 1);
                    else if (select <= 50)
                        y += rand.Next(-1, 1);

                    if (x < 0)
                    {
                        x = 0;
                    }
                    else if (x >= Map.Width)
                    {
                        x = Map.Width;
                    }

                    if (y < 0)
                    {
                        y = 0;
                    }
                    else if (y >= Map.Height)
                    {
                        y = Map.Height;
                    }
                }
            }
            return NewMap;
        }
    }
}
