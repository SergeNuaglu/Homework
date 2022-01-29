using System;

namespace MessageOutput
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string message;
            int outputsCount;

            Console.Write("Введите сообщение, которое хотите вывести: ");
            message = Console.ReadLine();
            Console.Write("Введите количество выводов: ");
            outputsCount = Convert.ToInt32(Console.ReadLine());

            while (outputsCount-- > 0)
            {
                Console.WriteLine(message);
            }
        }
    }
}
