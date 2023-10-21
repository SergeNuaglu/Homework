using System;

namespace Bracket_Expression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text;

            do
            {
                Console.Write("Введите строку из символов '(' и ')': ");
                text = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(text) || (text.IndexOf('(') < 0 && text.IndexOf(')') < 0));

            int depth = 0;
            int maxDepth = 0;

            foreach (char symbol in text)
            {
                if (depth > maxDepth)
                {
                    maxDepth = depth;
                }

                if (symbol == '(')
                {
                    depth++;
                }
                else if (symbol == ')')
                {
                    depth--;
                }

                if (depth < 0)
                {
                    break;
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
