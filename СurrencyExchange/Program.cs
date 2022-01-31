using System;

namespace СurrencyExchange
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            float rub;
            float usd;
            float euro;
            float currencyCount;
            float rubToUsd = 77.85f, rubToEuro = 87.45f;
            float usdToRub = 78.64f, usdToEuro = 1.11f;
            float euroToRub = 89.2f, euroToUsd = 1.13f;
            string sale;
            string buy;
            bool isContinue = true;


            Console.WriteLine("Ваш баланс:");
            Console.Write("Рубли - ");
            rub = Convert.ToSingle(Console.ReadLine());
            Console.Write("Доллары - ");
            usd = Convert.ToSingle(Console.ReadLine());
            Console.Write("Евро - ");
            euro = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Добро пожаловать в обменник валют!\nУ нас меняют рубли, доллары и евро\nДля выбора валюты введите соответствующий ей буквенный код" +
                "\nРубли - rub\nДоллары - usd\nЕвро - euro");

            while (isContinue)
            {
                Console.Write("Какую валюту хотите продать?: ");
                sale = Console.ReadLine();
                Console.Write("Какую валюту хотите купить?: ");
                buy = Console.ReadLine();
                Console.WriteLine($"Обмен {sale} на {buy}");
                Console.Write("Сколько хотите обменять?: ");
                currencyCount = Convert.ToSingle(Console.ReadLine());

                switch (sale)
                {
                    case "rub":
                        switch (buy)
                        {
                            case "usd":
                                if (rub >= currencyCount)
                                {
                                    usd += currencyCount / rubToUsd;
                                    rub -= currencyCount;
                                }
                                else
                                {
                                    Console.WriteLine("На вашем счете недостаточно средств");
                                }
                                break;
                            case "euro":
                                if (rub >= currencyCount)
                                {
                                    euro += currencyCount / rubToEuro;
                                    rub -= currencyCount;
                                }
                                else
                                {
                                    Console.WriteLine("На вашем счете недостаточно средств");
                                }
                                break;
                        }
                        break;
                    case "usd":
                        switch (buy)
                        {
                            case "rub":
                                if (usd >= currencyCount)
                                {
                                    rub += currencyCount * usdToRub;
                                    usd -= currencyCount;
                                }
                                else
                                {
                                    Console.WriteLine("На вашем счете недостаточно средств");
                                }
                                break;
                            case "euro":
                                if (usd >= currencyCount)
                                {
                                    euro += currencyCount / usdToEuro;
                                    usd -= currencyCount;
                                }
                                else
                                {
                                    Console.WriteLine("На вашем счете недостаточно средств");
                                }
                                break;
                        }
                        break;
                    case "euro":
                        switch (buy)
                        {
                            case "rub":
                                if (euro >= currencyCount)
                                {
                                    rub += currencyCount * euroToRub;
                                    euro -= currencyCount;
                                }
                                else
                                {
                                    Console.WriteLine("На вашем счете недостаточно средств");
                                }
                                break;
                            case "usd":
                                if (euro >= currencyCount)
                                {
                                    usd += currencyCount * euroToUsd;
                                    euro -= currencyCount;
                                }
                                else
                                {
                                    Console.WriteLine("На вашем счете недостаточно средств");
                                }
                                break;
                        }
                        break;
                }
                Console.WriteLine($"Ваш баланс: \nРубли - {rub}\nДоллары - {usd}\nЕвро - {euro}");
                Console.Write("Введите чтобы родолжить - 1 или завершить - 0: ");
                isContinue = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
            }
            Console.WriteLine("Всего доброго!");
        }
    }
}
