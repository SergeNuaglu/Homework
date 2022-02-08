using System;

namespace KansasCityShuffle
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            ShuffleArray(numbers);

            foreach (var item in numbers)
            {
                Console.Write(item);
            }

            Console.ReadKey();
        }

        static void ShuffleArray(int []array)
        {
            Random random = new Random();
            int newIndex;
            int tempVariabre;

            for (int i = 0; i < array.Length; i++)
            {
                newIndex = random.Next(0, array.Length - 1);
                tempVariabre = array[i];
                array[i] = array[newIndex];
                array[newIndex] = tempVariabre;
            }
        }
    }
}
