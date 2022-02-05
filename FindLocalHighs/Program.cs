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

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i != 0 && i != numbers.Length - 1)
                {
                    if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }
                else if (i == 0)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }
                else
                {
                    if (numbers[i] > numbers[i - 1])
                    {
                        Console.Write(numbers[i]);
                    }
                }
            }
        }
    }
}
