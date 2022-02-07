using System;

namespace UIElement
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            float barMaxSize = 10f;
            float health = 40f;
            float maxHealth = 100f;
            char fillSymbol = '#';
            int barXPosition = 0;
            int barYPosition = 0;
            float healthPercent;
            ConsoleColor barColor = ConsoleColor.DarkRed;

            healthPercent = health / (maxHealth / 100);
            DrawBar(healthPercent, barMaxSize, barXPosition, barYPosition, barColor, fillSymbol);

        }

        static void DrawBar(float fillPercent, float maxSize, int posX, int posY, ConsoleColor color, char symbol)
        {
            ConsoleColor defaultColor;
            defaultColor = Console.BackgroundColor;
            string bar = "";
            float barFillPercent = maxSize / 100 * fillPercent;

            for (int i = 0; i < barFillPercent; i++)
            {
                bar += symbol;
            }

            Console.SetCursorPosition(posX, posY);
            Console.Write("[");
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            bar = "";

            for (int i = (int)barFillPercent; i < maxSize; i++)
            {
                bar += " ";
            }

            Console.Write(bar + "]");
        }
    }
}
