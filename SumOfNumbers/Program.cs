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
            string operation = null;
            string userInput = null;
            bool isThisCommand = false;
            bool isAppWork = true;

            while (isAppWork)
            {
                Console.Clear();       
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("Команды:\nsum - сложить числа\nexit - выйти из программы\n\n");
                Console.SetCursorPosition(0, 5);

                if (userInput != "sum" && userInput != null)
                {
                    Console.Write("Операция сложения: " + operation);
                }
                else if (userInput == "sum")
                {
                    Console.Write("Операция сложения: " + operation + " = " + sum);
                    operation = null;
                    sum = 0;
                    Console.WriteLine("\nНажмите любую клавишу для новой операции...");
                    Console.ReadKey();
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Введите число или команду: ");
                userInput = Console.ReadLine();


                for (int i = 0; i < commands.Length && isThisCommand == false; i++)
                {
                    if (userInput == commands[i])
                    {
                        isThisCommand = true;
                    }
                }

                if (isThisCommand == false)
                {
                    float[] tempNumbers = new float[numbers.Length + 1];
                    tempNumbers[tempNumbers.Length - 1] = Convert.ToSingle(userInput);
                    sum += tempNumbers[tempNumbers.Length - 1];

                    if (operation == null)
                    {
                        operation += userInput;
                    }
                    else
                    {
                        operation += " + " + userInput;
                    }

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        tempNumbers[i] = numbers[i];
                    }

                    numbers = tempNumbers;
                }
                else
                {
                    switch (userInput)
                    {
                        case "sum":
                            if (numbers.Length >= 2)
                            {
                                numbers = new float[0];
                            }
                            else
                            {
                                userInput = " ";
                                Console.WriteLine("Для сложения нужно как минимум два числа!");
                                Console.WriteLine("Нажмите любую клавишу для того, чтобы попробовать еще...");
                                Console.ReadKey();
                            }
                            break;
                        case "exit":
                            isAppWork = false;
                            break;
                    }

                    isThisCommand = false;
                }
            }
        }
    }
}
