using System;

namespace Bracket_Expression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int depth = 0;
            int maxDepth = 0;
            char openingBracket = '(';
            char closingBracket = ')';
            string text;

            do
            {
                Console.Write($"Введите строку из символов {openingBracket} и {closingBracket}: "); ;
                text = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(text) || (text.IndexOf(openingBracket) < 0 && text.IndexOf(closingBracket) < 0));

            foreach (char symbol in text)
            {
                if (symbol == openingBracket)
                {
                    depth++;
                }
                else if (symbol == closingBracket)
                {
                    depth--;
                }

                if (depth < 0)
                {
                    break;
                }

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                }
            }

            if (depth != 0)
            {
                Console.WriteLine("Введено некорректное скобочное выражение");
            }
            else
            {
                Console.WriteLine("Введено корректное скобочное выражение, " +
                                  $"максимальная глубина = {maxDepth}");
            }

            Console.ReadKey();
        }
    }
}
