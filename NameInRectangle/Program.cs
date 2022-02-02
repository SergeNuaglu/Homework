using System;

namespace NameInRectangle
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string userName;
            char drawSymbol;
            int rectangleWidth;
            int rectangleHeight = 3;
            int borderWidth = 1;
            int borderCount = 2;

            Console.Write("Введите ваше имя: ");
            userName = Console.ReadLine();
            Console.Write("Введите символ для обрисовки вашего имени: ");
            drawSymbol = Convert.ToChar(Console.ReadLine());

            rectangleWidth = userName.Length + borderWidth * borderCount;

            for (int i = 1; i <= rectangleHeight; i++)
            {
                for (int k = 1; k <= rectangleWidth; k++)
                {
                    if (i == 2 && k != 1 && k < rectangleWidth)
                    {
                        Console.Write(userName);
                        k += userName.Length - borderWidth;
                        continue;
                    }
                    Console.Write(drawSymbol);
                }
                Console.Write("\n");
            }
        }
    }
}
