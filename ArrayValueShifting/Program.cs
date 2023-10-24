using System;

namespace ArrayValueShifting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int generatedNumbers = 5;
            int maximumRandomNumber = 100;

            var random = new Random();
            var numbers = new int[generatedNumbers];

            Console.Write("Исходный массив:  {");

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

            int shiftsNumber;

            do
            {
                Console.Write("Количество сдвигов влево: ");
            }
            while (!int.TryParse(Console.ReadLine(), out shiftsNumber));

            int remainder = shiftsNumber % generatedNumbers;

            if (remainder != 0)
            {
                int[] shiftedNumbers = new int[generatedNumbers];

                for (int i = 0; i < generatedNumbers; i++)
                {
                    shiftedNumbers[i] = numbers[(i + remainder) % generatedNumbers];
                }

                numbers = shiftedNumbers;
            }

            Console.Write("Получившийся массив: {");

            for (int i = 0; i < generatedNumbers; i++)
            {
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
