using System;

namespace SumOfNumbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            float[] numbers = new float[0];
            string[] commands = { "sum", "exit" };
            float sum = 0;
            string userInput;
            bool isThisCommand = false;
            bool isAppWork = true;

            while (isAppWork)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 6);
                Console.WriteLine("Команды:\nsum - сложить числа\nexit - выйти из программы\n\n");
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Введите число или команду: ");
                userInput = Console.ReadLine();
                float[] tempNumbers = new float[numbers.Length + 1];

                for (int i = 0; i < commands.Length; i++)
                {
                    if (userInput == commands[i])
                    {
                        isThisCommand = true;
                        break;
                    }
                }

                if (isThisCommand == false)
                {
                    tempNumbers[tempNumbers.Length - 1] = Convert.ToSingle(userInput);
                    numbers = tempNumbers;
                }
                else
                {
                    switch (userInput)
                    {
                        case "sum":
                            if (numbers.Length >= 2)
                            {
                                for (int i = 0; i < numbers.Length; i++)
                                {
                                    sum += numbers[i];    
                                }

                                Console.WriteLine("Сумма чисел = " + sum);
                                Console.WriteLine("Нажмите любую клавишу для новой операции...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Для сложения нужно как минимум два числа!");
                                Console.WriteLine("Нажмите любую клавишу для того, чтобы попробовать еще...");
                                Console.ReadKey();
                            }
                            break;
                        case "exit":
                            isAppWork = false;
                            break;
                        default:
                            Console.WriteLine("Такой команды нет!");
                            break;
                    }
                }
                Console.SetCursorPosition(0, 2);
                Console.Write("Операция: ");
            }
        }
    }
}
