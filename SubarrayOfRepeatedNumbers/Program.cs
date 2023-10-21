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

            for (int i = 0; i < generatedNumbers; i++)
            {
                int randomNumber = random.Next(maximumRandomNumber);
                numbers[i] = randomNumber;

                if (lastNumber == randomNumber)
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
                    lastNumber = randomNumber;
                }

                Console.Write(randomNumber);

                if (i != generatedNumbers - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.Write("}");
            Console.WriteLine(
                repeatNumber == -1
                    ? " - никакие из чисел подряд не повторяются"
                    : $" - число {repeatNumber} повторяется большее количество раз подряд - {maxRepetitions}");

            Console.ReadKey();
        }
    }
}
