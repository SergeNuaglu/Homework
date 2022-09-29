using System;

namespace Multiples
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int minRandomValue = 1;
            int maxRandomValue = 27;
            int randomNumber;
            int minThreeDigitNumber = 100;
            int maxThreeDigitNumber = 999;
            int numbersCount = 0;
            int multiple = 0;
            bool canWork = true;
            Random random = new Random();

            randomNumber = random.Next(minRandomValue, maxRandomValue);
            Console.Write("Количество трехзначных натуральных чисел, которые кратны " + randomNumber + ": ");

            while (canWork)
            {
                multiple += randomNumber;

                if (multiple >= minThreeDigitNumber && multiple <= maxThreeDigitNumber)
                    numbersCount++;
                else if (multiple > maxThreeDigitNumber)
                    canWork = false;
            }

            Console.Write(numbersCount);
        }
    }
}
