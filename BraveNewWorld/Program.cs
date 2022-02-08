using System;
using System.IO;

namespace BraveNewWorld
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            char[,] map =
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#'},
                {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#'},
                {'#',' ','#',' ','#','#','#',' ',' ','#','#',' ','#'},
                {'#',' ','#',' ',' ','©',' ',' ','#',' ',' ',' ','#'},
                {'#',' ','#',' ','#','#','#',' ','#',' ','#',' ','#'},
                {'#',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ','#'},
                {'#',' ','#',' ',' ',' ','#','#','#',' ','#',' ','#'},
                {'#','#','#','#','#','#','#','#','#','#','#','#','#',}
            };
            char player = '©';
            int playerX, playerY;
            int directionX, directionY;
            bool isAppWorking = true;

            DrowMap(map, out playerX, out playerY);

            while (isAppWorking)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    SetDirection(key, out directionX, out directionY);

                    if (map[playerX + directionX, playerY + directionY] != '#')
                    {
                        Move(map, player, ref playerX, ref playerY, directionX, directionY);
                    }
                }
            }
        }

        static void DrowMap(char[,] map, out int playerX, out int playerY)
        {
            playerX = 0;
            playerY = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);

                    if (map[i, j] == '©')
                    {
                        playerX = i;
                        playerY = j;
                        map[i, j] = ' ';
                    }                    
                }

                Console.WriteLine();
            }
        }

        static void SetDirection(ConsoleKeyInfo key, out int directionX, out int directionY)
        {
            directionX = 0;
            directionY = 0;

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    directionX = -1; directionY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    directionX = 1; directionY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    directionX = 0; directionY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    directionX = 0; directionY = 1;
                    break;
            }
        }

        static void Move(char[,] map, char playerSymbol, ref int playerX, ref int playerY, int directionX, int directionY)
        {
            Console.SetCursorPosition(playerY, playerX);
            Console.Write(map[playerX, playerY]);
            playerX += directionX;
            playerY += directionY;
            Console.SetCursorPosition(playerY, playerX);
            Console.Write(playerSymbol);
        }
    }
}
