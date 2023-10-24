using System;

namespace SubarrayOfRepeatedNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int generatedNumbers = 30;
            int maximumRandomNumber = 10;

            var random = new Random();
            var numbers = new int[generatedNumbers];

            int lastNumber = -1;
            int repeatNumber = -1;
            int repetitions = 1;
            int maxRepetitions = 0;

            Console.Write("{");

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(maximumRandomNumber);
                Console.Write(numbers[i]);

                if (i != numbers.Length - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.Write("}");

            foreach (int number in numbers)
            {
                if (lastNumber == number)
                {
                    repetitions++;

                    if (maxRepetitions < repetitions)
                    {
                        maxRepetitions = repetitions;
                        repeatNumber = lastNumber;
                    }
                }
                else
                {
                    repetitions = 1;
                    lastNumber = number;
                }
            }

            Console.WriteLine(
                repeatNumber == -1
                    ? " - никакие из чисел подряд не повторяются"
                    : $" - число {repeatNumber} повторяется большее количество раз подряд. Количество повторений - {maxRepetitions}");

            Console.ReadKey();
        }
    }
}