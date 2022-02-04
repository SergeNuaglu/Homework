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

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    Console.Write(numbers[i, j] + " ");

                    if (i == 1)
                    {
                        sum += numbers[i, j];
                    }

                    if (j == 0)
                    {
                        product *= numbers[i, j];
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Сумма второй строки: " + sum +
                "\nПроизведение первого столбца: " + product);
            Console.ReadKey();
        }
    }
}
