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

        private int[,] NewMap = new int[Map.Width, Map.Height];

        public int[,] Generate()
        {
            var rand = new Random();

            for (int i = 0; i < Map.Width / 2 * 3; i++)
            {
                int x = rand.Next(0, Map.Width - 1);
                int y = rand.Next(0, Map.Height - 1);
                for (int j = 0; j < Map.Width / 5; j++)
                {
                    NewMap[x, y] = 1;
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


/*
namespace MapV2
{
    class Map
    {
        static void Main(string[] args)
        {
            const int side = 15;
            //const int FullMapSize = 150;
            int[,] Map;
            //int[,] FullMap = new int[FullMapSize, FullMapSize];
            Map = MapGen(side);
            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                    Console.Write(Map[i, j]);
                Console.Write("\n");
            }
            Console.ReadKey();
            return;
        }

        static int[,] MapGen(int side)
        {
            int[,] Map = new int[side, side];
            Random rand = new Random();
            for (int i = 0; i < side; i++)
            {
                for (int j = 0; j < side; j++)
                    Map[i, j] = rand.Next(0, 2);
            }

            return Map;
        }
    }
}*/