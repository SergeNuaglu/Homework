using System;
using System.Collections.Generic;

namespace PlayerDatabase
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            dataBase.Work();
        }

        class DataBase
        {
            private Dictionary<int, Player> _players = new Dictionary<int, Player>();

            public void AddPlayer()
            {
                string nickname;
                int number;
                int level;

                Console.Write("Никнейм игрока - ");
                nickname = Console.ReadLine();
                Console.Write("Номер игрока - ");
                number = Convert.ToInt32(Console.ReadLine());
                Console.Write("Уровень игрока - ");
                level = Convert.ToInt32(Console.ReadLine());
                Player player = new Player(nickname, number, level);
                _players.Add(number, player);
            }

            public void DeletePlayer()
            {
                Console.Write("Номер игрока - ");
                _players.Remove(Convert.ToInt32(Console.ReadLine()));
            }

            public void BanPlayer()
            {
                int number;
                Console.Write("Номер игрока - ");
                number = Convert.ToInt32(Console.ReadLine());
                _players[number].Ban();
            }

            public void UnbanPlayer()
            {
                int number;
                Console.Write("Номер игрока - ");
                number = Convert.ToInt32(Console.ReadLine());
                _players[number].Unban();
            }

            public void Work()
            {
                bool isWork = true;

                while (isWork)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 12);

                    foreach (var player in _players)
                    {
                        Console.WriteLine($"{player.Key} - {player.Value.Nickname}");
                    }

                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("База данных игроков:\n");
                    Console.WriteLine("Добавить игрока  - 1\nУдалить игрока   - 2\nЗабанить игрока  - 3\nРазбанить игрока - 4\n");
                    Console.Write("Введите номер операции: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            AddPlayer();
                            break;
                        case "2":
                            DeletePlayer();
                            break;
                        case "3":
                            BanPlayer();
                            break;
                        case "4":
                            UnbanPlayer();
                            break;
                        case "5":
                            isWork = false;
                            break;
                    }
                }
            }
        }

        class Player
        {
            private int _level;
            private bool _isBan = false;

            public string Nickname { get; private set; }

            public int Number { get; private set; }

            public Player(string nickname, int number, int level)
            {
                Nickname = nickname;
                Number = number;
                _level = level;
            }

            public void Ban()
            {
                if (_isBan == false)
                {
                    _isBan = true;
                }
                else
                {
                    Console.WriteLine("Игрок уже забанен");
                }
            }

            public void Unban()
            {
                if (_isBan == true)
                {
                    _isBan = false;
                }
                else
                {
                    Console.WriteLine("Игрок уже разбанен");
                }
            }
        }
    }
}
