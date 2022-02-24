using System;
using System.Collections.Generic;
using System.Linq;

namespace TopPlayers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int topPlayersCount = 3;
            List<Player> players = new List<Player>();

            players.Add(new Player("Алексей", 55, 5));
            players.Add(new Player("Генадий", 74, 6));
            players.Add(new Player("Иван", 36, 5));
            players.Add(new Player("Петр", 65, 4));
            players.Add(new Player("Николай", 45, 3));
            players.Add(new Player("Илья", 70, 9));
            players.Add(new Player("Михаил", 68, 7));
            players.Add(new Player("Антон", 50, 6));
            players.Add(new Player("Николай", 34, 2));
            players.Add(new Player("Владислав", 90, 8));

            Console.WriteLine("Все игроки:\n");
            ShowAllPlayers(players);
            var topPlayers = players.OrderByDescending(player => player.Power).Take(topPlayersCount).ToList();
            Console.WriteLine($"\nТоп {topPlayersCount} игроков по силе:\n");
            ShowAllPlayers(topPlayers);
            topPlayers = players.OrderByDescending(player => player.Level).Take(topPlayersCount).ToList();
            Console.WriteLine($"\nТоп {topPlayersCount} игроков по уровню:\n");
            ShowAllPlayers(topPlayers);
            Console.ReadKey();

        }

        public static void ShowAllPlayers(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine(player.Name + ", cила: " + player.Power + ", уровень: "+player.Level);
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Power { get; private set; }
        public int Level { get; private set; }

        public Player(string fullName, int power, int level)
        {
            Name = fullName;
            Power = power;
            Level = level;
        }
    }
}
