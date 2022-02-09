using System;
using System.Collections.Generic;

namespace QueueToStore
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool isCustomerServing = true;
            int storeAccount = 0;
            Queue<int> purchasAmounts = new Queue<int>();

            purchasAmounts.Enqueue(234);
            purchasAmounts.Enqueue(36);
            purchasAmounts.Enqueue(91);
            purchasAmounts.Enqueue(123);
            purchasAmounts.Enqueue(345);

            while (isCustomerServing)
            {
                Console.Clear();
                Console.WriteLine("На счету: " + storeAccount);

                if (purchasAmounts.Count != 0)
                {
                    Console.WriteLine("Следующий клиент делает покупку на сумму: " + purchasAmounts.Peek());
                    storeAccount += purchasAmounts.Dequeue();    
                }
                else
                {
                    isCustomerServing = false;
                }
                
                Console.ReadKey();
            }    
        }
    }
}
