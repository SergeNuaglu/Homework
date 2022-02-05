using System;

namespace LargestElement
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int[,] numbers = new int[10, 10];
            int largestNumber = int.MinValue;
            int largerNumberRow = 0;
            int largerNumberColumn = 0;

            Console.WriteLine("Исходная матрица:\n\n");

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    numbers[i, j] = random.Next(10, 99);
                    Console.Write(numbers[i, j] + " ");

                    if (largestNumber < numbers[i, j])
                    {
                        largestNumber = numbers[i, j];
                        largerNumberRow = i;
                        largerNumberColumn = j;
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("\n\nНаибольший элемент: " + largestNumber + "\n\n");
            numbers[largerNumberRow, largerNumberColumn] = 0;
            Console.WriteLine("Полученная матрица:\n\n");

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if(numbers[i,j] == largestNumber)
                    {
                        numbers[i, j] = 0;
                    }

                    Console.Write(numbers[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
