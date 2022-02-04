using System;

namespace Arrey
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[,] numbers =
            {
                {5,3,4,8,9},
                {3,7,3,5,4}
            };
            int sum = 0;
            int product = 1;
            int rowToAdd = 2;
            int columnToMultiply = 1;

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    Console.Write(numbers[i, j] + " ");
                }

                Console.WriteLine();
            }

            for (int i = 0; i < numbers.GetLength(1); i++)
            {
                sum += numbers[rowToAdd - 1, i];
            }

            for (int i = 0; i < numbers.GetLength(0);i++)
            {
                product *= numbers[columnToMultiply - 1, i];
            }

            Console.WriteLine("Сумма второй строки: " + sum +
                "\nПроизведение первого столбца: " + product);
            Console.ReadKey();
        }
    }
}
