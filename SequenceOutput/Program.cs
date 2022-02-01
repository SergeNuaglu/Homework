using System;

namespace SequenceOutput
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int boundOfSequence = 100;

            for (int i = 0; i < boundOfSequence; i++)
            {
                if (i % 7 == 0)
                {
                    Console.Write(i + " ");
                }
            }
            Console.ReadKey();
        }
    }
}

