using System;

namespace SumOfNumbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            float[] numbers = new float[0];
            string sumCommand = "sum";
            string exitCommand = "exit";
            float sum = 0;
            string userInput;
            bool isAppWork = true;
            
            while (isAppWork)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Команды:\nsum - сложить числа\nexit - выйти из программы\n\n");
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Введите число или команду: ");
                userInput = Console.ReadLine();

                if (userInput == sumCommand)
                {
                    if (numbers.Length >= 2)
                    {
                        Console.WriteLine("Сумма чисел = " + sum);
                        Console.ReadKey();
                        sum = 0;
                        numbers = new float[0];
                    }
                    else
                    {
                        Console.WriteLine("Для сложения нужно как минимум два числа!");
                        Console.ReadKey();
                    }
                }
                else if(userInput == exitCommand)
                {
                    isAppWork = false;
                }
                else
                {
                    float[] tempNumbers = new float[numbers.Length + 1];
                    tempNumbers[tempNumbers.Length - 1] = Convert.ToSingle(userInput);
                    sum += tempNumbers[tempNumbers.Length - 1];

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        tempNumbers[i] = numbers[i];
                    }

                    numbers = tempNumbers;
                }
            }
        }
    }
}
