using System;
using System.Collections.Generic;

namespace PlayerDatabase
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Database database = new Database();
            database.Work();
        }

        class Database
        {
            private Dictionary<int, Player> _players = new Dictionary<int, Player>();

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
                    Console.WriteLine("Добавить игрока  - 1\nУдалить игрока   - 2\nЗабанить игрока  - 3\nРазбанить игрока - 4\nВыход - 5\n");
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

            private void AddPlayer()
            {
                string nickname;
                int number;
                int level;

                Console.Write("Никнейм игрока - ");
                nickname = Console.ReadLine();
                Console.Write("Номер игрока - ");

                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (_players.ContainsKey(number))
                    {
                        Console.WriteLine("Игрок под таким номером уже есть в базе");
                    }
                    else
                    {
                        Console.Write("Уровень игрока - ");

                        if (int.TryParse(Console.ReadLine(), out level))
                        {
                            Player player = new Player(nickname, number, level);
                            _players.Add(number, player);
                        }
                        else
                        {
                            Console.WriteLine("Некоректный ввод.");
                        }
                    }                 
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }

                Console.ReadKey();
            }

            private void DeletePlayer()
            {
                int number;

                Console.Write("Номер игрока - ");

                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (_players.ContainsKey(number))
                    {
                        _players.Remove(number);
                        Console.WriteLine($"Игрок под эти номером {number} удален из базы");
                    }
                    else
                    {
                        Console.WriteLine($"Игрока под номером {number} нет в базе");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }

                Console.ReadKey();
            }

            private void BanPlayer()
            {
                int number;
                Console.Write("Номер игрока - ");

                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (_players.ContainsKey(number))
                    {
                        _players[number].Ban();
                    }
                    else
                    {
                        Console.WriteLine($"Игрока под номером {number} нет в базе");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }

                Console.ReadKey();
            }

            private void UnbanPlayer()
            {
                int number;
                Console.Write("Номер игрока - ");

                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (_players.ContainsKey(number))
                    {
                        _players[number].Unban();
                    }
                    else
                    {
                        Console.WriteLine($"Игрока под номером {number} нет в базе");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                }

                Console.ReadKey();
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
