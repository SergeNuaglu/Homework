using System;

namespace СurrencyExchange
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            float rubCount;
            float usdCount;
            float euroCount;

            Console.WriteLine("Ваш баланс:");
            Console.Write("Рубли - ");
            rubCount = Convert.ToSingle(Console.ReadLine());
            Console.Write("Доллары - ");
            usdCount = Convert.ToSingle(Console.ReadLine());
            Console.Write("Евро - ");
            euroCount = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Добро пожаловать в обменник валют!\nЗдесь можно обменять 3 валюты: рубли, доллары и евро.\nЧто продаете?");
            Console.Write("Что продаете?");
        }
    }
}
