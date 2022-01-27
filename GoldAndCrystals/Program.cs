using System;

namespace GoldAndCrystals
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int crystalPrice = 5;
            int goldCount;
            int crystalCount;
            bool isEnoughGold;

            Console.WriteLine("Добро пожаловать!\nВ нашем магазине кристаллы по цене: " + crystalPrice);
            Console.Write("Сколько золота у вас? : ");
            goldCount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько кристаллов хотите купить? : ");
            crystalCount = Convert.ToInt32(Console.ReadLine());

            isEnoughGold = goldCount >= crystalCount * crystalPrice;

            crystalCount *= Convert.ToInt32(isEnoughGold);
            goldCount -= crystalCount * crystalPrice;

            Console.WriteLine("У вас\nзолота: " + goldCount + "\nкристаллов: " + crystalCount);
        }
    }
}
