using System;

namespace PowerOfTwo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            byte randomNumber;
            int power = 0;
            int factor = 2;
            int result;

            randomNumber = (byte)random.Next(byte.MinValue, byte.MaxValue);

            for (result = 1; result <= randomNumber; result *= factor)
            {
                power++;
            }

            Console.WriteLine("Заданное число - " + randomNumber +
                "\nMинимальная степень двойки - " + power +
                "\nЧисло, превосходящее заданное - " + result);
        }
    }
}
