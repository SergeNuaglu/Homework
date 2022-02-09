using System;
using System.Collections.Generic;

namespace QueueToStore
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int storeAccount = 0;
            Queue<int> purchasAmounts = new Queue<int>();

            purchasAmounts.Enqueue(234);
            purchasAmounts.Enqueue(36);
            purchasAmounts.Enqueue(91);
            purchasAmounts.Enqueue(123);
            purchasAmounts.Enqueue(345);

            while (purchasAmounts.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("На счету: " + storeAccount);
                Console.WriteLine("Следующий клиент делает покупку на сумму: " + purchasAmounts.Peek());
                ServeClient(ref storeAccount, ref purchasAmounts);
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine("На счету: " + storeAccount);
            Console.ReadKey();
        }

        static void ServeClient(ref int account, ref Queue<int> purchasAmounts)
        {
            account += purchasAmounts.Dequeue();
        }
    }
}
