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
            int[] productPrices = { 230, 65, 120, 87, 56, 350, 89, 47, 20, 130, 56, 80, 45, 70, 89 };
            Queue<string> queueToStore = new Queue<string>();

            queueToStore.Enqueue("Петрович");
            queueToStore.Enqueue("Баб Маша");
            queueToStore.Enqueue("Профессор");
            queueToStore.Enqueue("Школьник");
            queueToStore.Enqueue("Качок");

            while (isCustomerServing)
            {
                Console.Clear();
                Console.WriteLine("На счету: " + storeAccount);

                if (queueToStore.Count != 0)
                {
                    Console.WriteLine("Следующий клиент: " + queueToStore.Peek());
                    ServeClient(ref storeAccount, productPrices, queueToStore.Dequeue());    
                }
                else
                {
                    Console.WriteLine("Никого нет, можно хлебнуть чайку");
                    isCustomerServing = false;
                }
                
                Console.ReadKey();
            }    
        }

       static void ServeClient(ref int account, int [] prices, string client)
        {
            Random random = new Random();
            int productPrice = prices[random.Next(0,prices.Length)];
            account += productPrice;
        }
    }
}
