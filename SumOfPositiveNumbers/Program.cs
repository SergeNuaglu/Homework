﻿using System;

namespace SumOfPositiveNumbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int minRandomValue = 0;
            int maxRandomValue = 100;
            int firstDivider = 3;
            int secondDivider = 5;
            int multiplicityIndicator = 0;
            int result = 0;
            int randomNumber;
            Random random = new Random();

            randomNumber = random.Next(minRandomValue, maxRandomValue);
            Console.WriteLine("Рандомное число: " + randomNumber);

            for (int i = 0; i <= randomNumber; i++)
            {
                if (i % firstDivider == multiplicityIndicator || i % secondDivider == multiplicityIndicator)
                    result += i;
            }

            Console.WriteLine("Сумма всех положительных чисел меньше " + randomNumber + " (включая число)," +
                "\nкоторые кратные " + firstDivider + " или " + secondDivider + ":");
            Console.WriteLine(result);
        }
    }
}
