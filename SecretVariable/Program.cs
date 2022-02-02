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

            Console.WriteLine("Введите пароль!" +
                "\nУ вас есть 3 попытки");

            for(int i = 1; i <= attemptsCount; i++)
            {
                Console.Write("Попытка №" + i + ": ");
                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine(secretMessage);
                    Console.ReadKey();
                    break;
                }
                Console.WriteLine("Неверный пароль!");
            }
  
            if(userInput != password)
            {
                Console.WriteLine("Вы исчерпали допустимое количество попыток!");
            }
        }
    }
}
