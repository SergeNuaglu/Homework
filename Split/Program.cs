using System;

namespace Split
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text;

            do
            {
                Console.Write("Введите текст: ");
                text = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(text));

            string[] splitText = text.Split(' ');

            foreach (string word in splitText)
            {
                Console.WriteLine(word);
            }

            Console.ReadKey();
        }
    }
}
