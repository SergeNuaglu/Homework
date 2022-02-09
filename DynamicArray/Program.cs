using System;
using System.Collections.Generic;

namespace SumOfNumbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<float> numbers = new List<float>();
            string sumCommand = "sum";
            string exitCommand = "exit";
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

                if (IsNumberBeAdded(userInput, numbers) == false)
                {
                    if (sumCommand == userInput)
                    {
                        if (numbers.Count >= 2)
                        {
                            Console.WriteLine("Сумма чисел = " + GetSumOfNumbers(numbers));
                        }
                        else
                        {
                            Console.WriteLine("Для сложения нужно как минимум два числа!");
                        }

                        Console.ReadKey();
                    }
                    else if (exitCommand == userInput)
                    {
                        isAppWork = false;
                    }
                }
            }
        }

        static bool IsNumberBeAdded(string userInput, List<float> numbers)
        {
            float number;

            if (float.TryParse(userInput, out number))
            {
                numbers.Add(number);
                return true;
            }
            else
            {
                return false;
            }
        }

        static float GetSumOfNumbers(List<float> numbers)
        {
            float sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }
    }
}
