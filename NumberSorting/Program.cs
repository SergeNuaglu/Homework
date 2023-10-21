using System;

namespace NumberSorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int generatedNumbers = 10;
            int maximumRandomNumber = 100;

            var random = new Random();
            var numbers = new int[generatedNumbers];

            Console.Write("Изначальный массив:     {");

            for (int i = 0; i < generatedNumbers; i++)
            {
                int randomNumber = random.Next(maximumRandomNumber);
                numbers[i] = randomNumber;

                Console.Write(randomNumber);

                if (i != generatedNumbers - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine("}");
            Console.Write("Отсортированный массив: {");

            for (var i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                int smallestNumber = currentNumber;
                int smallestIndex = -1;

                for (var j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < smallestNumber)
                    {
                        smallestNumber = numbers[j];
                        smallestIndex = j;
                    }
                }

                if (smallestIndex != -1)
                {
                    numbers[i] = numbers[smallestIndex];
                    numbers[smallestIndex] = currentNumber;
                }

                Console.Write(numbers[i]);

                if (i != generatedNumbers - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine("}");
            Console.ReadKey();
        }
    }
}
