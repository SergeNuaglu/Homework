using System;

namespace StopWord
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string stopWord = "exit";
            string userWord;

            Console.Write("Чтобы завершить программу введите exit: ");
            userWord = Console.ReadLine();

            while (userWord != stopWord)
            {
                Console.Write("Не то! Введите exit: ");
                userWord = Console.ReadLine();
            }

            Console.WriteLine("Программа завершена!");
        }
    }
}

