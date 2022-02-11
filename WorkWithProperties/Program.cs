using System;

namespace WorkWithProperties
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Player player = new Player(10, 5, '@');
            Renderer renderer = new Renderer();
            renderer.DrawPlayer(player.PositionX, player.PositionY, player.Symbol);
        }

        class Player
        {
            public char Symbol { get; private set; }
            public int PositionX { get; private set; }
            public int PositionY { get; private set; }

            public Player(int positionX, int positionY, char playerSymbol)
            {
                PositionX = positionX;
                PositionY = positionY;
                Symbol = playerSymbol;
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
