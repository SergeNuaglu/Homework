using System;

namespace WorkWithProperties
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Player player = new Player(10, 5);
            Renderer renderer = new Renderer();
            renderer.DrawPlayer(player, '@');
        }

        class Player
        {
            private int _x;
            private int _y;

            public int X
            {
                get
                {
                    return _x;
                }
                private set
                {
                    _x = value;
                }
            }

            public int Y
            {
                get
                {
                    return _y;
                }
                private set
                {
                    _y = value;
                }
            }

            public Player(int x, int y)
            {
                _x = x;
                _y = y;
            }
        }

        class Renderer
        {
            public void DrawPlayer(Player player, char symbol)
            {
                Console.SetCursorPosition(player.X, player.Y);
                Console.Write(symbol);
            }
        }
    }
}
