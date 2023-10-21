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

            Console.Write("Изначальный массив:  {");

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
            while (int.TryParse(Console.ReadLine(), out shiftsNumber) == false);

            for (int i = 0; i < shiftsNumber; i++)
            {
                for (var j = 1; j < numbers.Length; j++)
                {
                    int currentNumber = numbers[j];
                    int newIndex = j - 1;
                    newIndex = newIndex < 0 ? newIndex + numbers.Length : newIndex;

                    numbers[j] = numbers[newIndex];
                    numbers[newIndex] = currentNumber;
                }
            }

            Console.Write("Получившийся массив: {");

            for (var i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]);

                if (i != numbers.Length - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine("}");
            Console.ReadKey();
        }
    }
}
