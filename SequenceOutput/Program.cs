using System;

namespace SequenceOutput
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            for(int i = 0; i < 100; i++)
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
