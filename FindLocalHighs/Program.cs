using System;

namespace FindLocalHighs
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[30];

            Console.Write("Массив: ");

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0, 10);
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine("\n");
            Console.Write("Локальные максимумы: ");

            if (numbers[0] > numbers[1])
            {
                Console.Write(numbers[0] + " ");
            }

            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
                {
                    Console.Write(numbers[i] + " ");
                }
            }

            if (numbers[numbers.Length - 1] > numbers[numbers.Length - 2])
            {
                Console.Write(numbers[numbers.Length - 1]);
            }
        }
    }
}
