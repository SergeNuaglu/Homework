using System;

namespace WorkWithProperties
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Player player = new Player(10, 5, '@');
            Renderer renderer = new Renderer();
            renderer.DrawPlayer(player.PositionX, player.PositionY, player.PlayerSymbol);
        }

        class Player
        {
            public char PlayerSymbol { get; private set; }
            public int PositionX { get; private set; }
            public int PositionY { get; private set; }

            public Player(int x, int y, char playerSymbol)
            {
                PositionX = x;
                PositionY = y;
                PlayerSymbol = playerSymbol;
            }
        }

        class Renderer
        {
            public void DrawPlayer(int positionX, int positionY, char symbol)
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(symbol);
            }
        }
    }
}
