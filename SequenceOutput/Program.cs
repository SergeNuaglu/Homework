using System;

namespace SequenceOutput
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int boundOfSequence = 100;
            int divider = 7;

            for (int i = 0; i < boundOfSequence; i++)
            {
                if (i % divider == 0)
                {
                    Console.Write(i + " ");
                }
            }
            Console.ReadKey();
        }
    }
}
