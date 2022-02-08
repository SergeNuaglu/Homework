using System;

namespace ReadInt
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int number;

            ReadInt(out number);
        }

        static int ReadInt(out int number)
        {
            while (Int32.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.Clear();
                Console.Write("Введите число: ");  
            }

            return number;
        }
    }
}
