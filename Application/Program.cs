using System;

namespace Application
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random rand = new Random();
            float goldCount = 50;
            float health1 = 0;
            int armor1 = 0;
            int damage1 = 0;
            float winningChance1;
            float rateCoefficient1 = 0;
            float health2 = 0;
            int armor2 = 0;
            int damage2 = 0;
            int minHealth = 50;
            int maxHealth = 101;
            int minArmor = 50;
            int maxArmor = 101;
            int minDamage = 10;
            int maxDamage = 40;
            float winningChance2;
            float rateCoefficient2 = 0;
            int maxWinningChance = 100;
            string bet = "Нет ставок!";
            int betSize = 0;
            int winCount = 0;
            int lossCount = 0;
            int level;
            int goldForNextLevel = 500;
            string userInput;
            bool isAppWork = true;
            bool isPlacingBet = true;
            bool isFight = false;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("ROBOxBET");
            Console.WriteLine("Добро пожаловать в приложение RoboxBet!" +
                "\nДелайте ставки на сражениях роботов!");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();

            while (isAppWork)
            {
                Console.Clear();
                Console.WriteLine("Команда       / Действие" +
                "\nStat          / Статистика" +
                "\nFights        / Поставить на бой" +
                "\nWatchFight    / Смотреть сражение" +
                "\nExit          / Выход из игры");
                Console.Write("Введите команду: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "Stat":
                        Console.Clear();
                        level = (int)goldCount / goldForNextLevel;
                        Console.WriteLine("У вас золота: " + goldCount +
                            "\nКолличество побед: " + winCount +
                            "\nКолличество поражений: " + lossCount +
                            "\nВаш опыт каппера: " + level);
                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;

                    case "Fights":
                        while (isPlacingBet)
                        {
                            Console.Clear();

                            health1 = rand.Next(minHealth, maxHealth);
                            armor1 = rand.Next(minArmor, maxArmor);
                            damage1 = rand.Next(minDamage, maxDamage);
                            health2 = rand.Next(minHealth, maxHealth);
                            armor2 = rand.Next(minArmor, maxArmor);
                            damage2 = rand.Next(minDamage, maxDamage);

                            winningChance1 = (health1 + armor1 + damage1) / ((health1 + armor1 + damage1 + health2 + armor2 + damage2) / maxWinningChance);
                            winningChance2 = (health2 + armor2 + damage2) / ((health1 + armor1 + damage1 + health2 + armor2 + damage2) / maxWinningChance);
                            rateCoefficient1 = maxWinningChance / winningChance1;
                            rateCoefficient2 = maxWinningChance / winningChance2;

                            Console.WriteLine("Машина:              Robot1    Robot2" +
                                "\nТехсостояние:        " + health1 + "        " + health2 +
                                "\nБроня:               " + armor1 + "        " + armor2 +
                                "\nНаносимый урон:      " + damage1 + "        " + damage2 +
                                "\nКоэффицент ставки:   " + rateCoefficient1);
                            Console.SetCursorPosition(31, 4);
                            Console.WriteLine(rateCoefficient2);
                            Console.WriteLine("Введите для продолжения:" +
                                "\nСтавка на Robot1 - 1\nСтавка на Robot2 - 2\nОтказаться от ставки - 3\nНайти другой бой - любая клавиша");
                            Console.Write("Ваше решение: ");
                            userInput = Console.ReadLine();

                            if (userInput == "1")
                            {
                                bet = "Robot1";
                                Console.Write("Укажите размер ставки: ");
                                betSize = Convert.ToInt32(Console.ReadLine());
                                isFight = true;
                                break;

                            }
                            else if (userInput == "2")
                            {
                                bet = "Robot2";
                                Console.Write("Укажите размер ставки: ");
                                betSize = Convert.ToInt32(Console.ReadLine());
                                isFight = true;
                                break;
                            }
                            else if (userInput == "3")
                            {
                                break;
                            }
                        }

                        if (goldCount >= betSize)
                        {
                            Console.WriteLine("Ваша ставка: " + betSize + " золота на " + bet +
                                "\nВы можете посмотреть сражение через команду \"WatchFight\"");
                            isPlacingBet = false;
                        }
                        else if (goldCount < betSize)
                        {
                            Console.WriteLine("У вас недостаточно золота!");
                        }

                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;

                    case "WatchFight":
                        Console.Clear();
                        while (isFight)
                        {
                            for(int i = 0; health1 > 0 && health2 > 0; i++)
                            {
                                health1 -= Convert.ToSingle(rand.Next(0, damage2)) / 100 * (100 - armor1);
                                health2 -= Convert.ToSingle(rand.Next(0, damage1)) / 100 * (100 - armor2);
                                Console.WriteLine("Удар " + i + "-й");
                                Console.WriteLine("Техсостояние Robot1: " + health1);
                                Console.WriteLine("Техсостояние Robot2: " + health2);
                            }
                            break;
                        }

                        if (isFight)
                        {
                            if (health1 <= 0 && health2 <= 0)
                            {
                                Console.WriteLine("Ничья. Роботы уничножили друг друга.\nВаш запас золота не изменился.\nПопробуйте еще");
                            }
                            else if (health1 <= 0)
                            {
                                if (bet == "Robot2")
                                {
                                    Console.WriteLine("Победа! Ваш выйгрыш составил: " + (betSize * rateCoefficient1) + " золота");
                                    goldCount += betSize * rateCoefficient1;
                                    winCount++;
                                }
                                else
                                {
                                    Console.WriteLine("Очень жаль! Вы проиграли " + betSize + " золота");
                                    goldCount -= betSize;
                                    lossCount++;
                                }
                            }
                            else if (health2 <= 0)
                            {
                                if (bet == "Robot1")
                                {
                                    Console.WriteLine("Победа! Ваш выйгрыш составил: " + (betSize * rateCoefficient2) + " золота");
                                    goldCount += betSize * rateCoefficient2;
                                    winCount++;
                                }
                                else
                                {
                                    Console.WriteLine("Очень жаль! Вы проиграли " + betSize + " золота");
                                    goldCount -= betSize;
                                    lossCount++;
                                }
                            }
                            isPlacingBet = true;
                        }

                        if (!isFight)
                        {
                            Console.WriteLine("Сначала выберите бой и сделайте ставку с помощью команды \"Fights\"");
                        }

                        isFight = false;
                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;

                    case "Exit":
                        Console.Clear();
                        isAppWork = false;
                        Console.WriteLine("Вы вышли из приложения!");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка набора команды. Попробуйте еще раз.");
                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
