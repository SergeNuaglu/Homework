using System;

namespace Multiples
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int minRandomValue = 1;
            int maxRandomValue = 27;
            int lowerRange = 100;
            int upperRange = 999;
            int numbersCount = 0;
            int step;
            Random random = new Random();

            step = random.Next(minRandomValue, maxRandomValue);
            Console.Write("Количество трехзначных натуральных чисел, которые кратны " + step + ": ");


            for (int i = 0; i <= upperRange; i += step)
            {
                if (i >= lowerRange)
                    numbersCount++;
            }

            Console.Write(numbersCount);
        }
    }
}
