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
    }

    class Database
    {
        private Dictionary<string, Player> _players = new Dictionary<string, Player>();

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
            string playerNumber;
            string level;

            Console.Write("Никнейм игрока - ");
            nickname = Console.ReadLine();
            Console.Write("Номер игрока - ");
            playerNumber = Console.ReadLine();

            if (_players.ContainsKey(playerNumber))
            {
                Console.WriteLine("Игрок под таким номером уже есть в базе");
            }
            else
            {
                Console.Write("Уровень игрока - ");
                level = Console.ReadLine();
                Player player = new Player(nickname, playerNumber, level);
                _players.Add(playerNumber, player);
            }

            Console.ReadKey();
        }

        private void DeletePlayer()
        {
            string playerNumber;

            Console.Write("Номер игрока - ");
            playerNumber = Console.ReadLine();

            if (_players.ContainsKey(playerNumber))
            {
                _players.Remove(playerNumber);
                Console.WriteLine($"Игрок под эти номером {playerNumber} удален из базы");
            }
            else
            {
                Console.WriteLine($"Игрока под номером {playerNumber} нет в базе");
            }

            Console.ReadKey();
        }

        private void BanPlayer()
        {
            string playerNumber;
            Console.Write("Номер игрока - ");
            playerNumber = Console.ReadLine();

                if (_players.ContainsKey(playerNumber))
                {
                    _players[playerNumber].Ban();
                }
                else
                {
                    Console.WriteLine($"Игрока под номером {playerNumber} нет в базе");
                }

            Console.ReadKey();
        }

        private void UnbanPlayer()
        {
            string playerNumber;
            Console.Write("Номер игрока - ");
            playerNumber = Console.ReadLine();

            if (_players.ContainsKey(playerNumber))
            {
                _players[playerNumber].Unban();
            }
            else
            {
                Console.WriteLine($"Игрока под номером {playerNumber} нет в базе");
            }

            Console.ReadKey();
        }
    }

    class Player
    {
        private string _level;
        private bool _isBan = false;


        public string Nickname { get; private set; }

        public string Number { get; private set; }

        public Player(string nickname, string number, string level)
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
