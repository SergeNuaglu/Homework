using System;

namespace SecretVariable
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string secretMessage = "Вам доступны тайные знания иллюминатов!";
            string password;
            int attemptsCount = 3;
            string userInput = "";

            Console.WriteLine("Придумайте и введите пароль: ");
            password = Console.ReadLine();

            Console.WriteLine("Введите пароль!");

            while (attemptsCount > 0)
            {
                Console.WriteLine("Количество оставшихся попыток: " + attemptsCount);
                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine(secretMessage);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    if(attemptsCount > 1)
                    {
                        Console.WriteLine($"Неверный пароль! Попробуйте ещё");
                    }
                }
                attemptsCount--;
            }

            if(userInput != password)
            {
                Console.WriteLine("Вы исчерпали допустимое количество попыток!");
            }
        }
    }
}
