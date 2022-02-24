using System;
using System.Collections.Generic;
using System.Linq;

namespace UnificationOfTroops
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Soldier> squadB = new List<Soldier>();
            List<Soldier> squadA = new List<Soldier>();

            squadA.Add(new Soldier("Басов Н.Л."));
            squadA.Add(new Soldier("Самохвал Д.С."));
            squadA.Add(new Soldier("Черный С.С."));
            squadA.Add(new Soldier("Быков Б.К."));
            squadA.Add(new Soldier("Гонда Н.Л."));
            squadA.Add(new Soldier("Бочкин Д.С."));
            squadA.Add(new Soldier("Черногуб С.С."));
            squadB.Add(new Soldier("Сухаркин В.И"));
            squadB.Add(new Soldier("Загидулин М.Р"));
            squadB.Add(new Soldier("Кидалов Ю.О"));
            squadB.Add(new Soldier("Хамюк В.А."));
            squadB.Add(new Soldier("Стоянов Т.К."));
            squadB.Add(new Soldier("Хвалебин Р.Д."));
            squadB.Add(new Soldier("Угрюмов Б.К."));
            squadB = squadB.Union(squadA.Where(soldier => soldier.Name.StartsWith("Б"))).ToList();
            squadA = squadA.OrderBy(soldier => soldier.Name).SkipWhile(soldier => soldier.Name.StartsWith("Б")).ToList();
            Console.WriteLine("Отряд А:");
            ShowAllSoldier(squadA);
            Console.WriteLine("Отряд Б:");
            ShowAllSoldier(squadB);
        }

        public static void ShowAllSoldier(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.Name);
            }

            Console.WriteLine();
        }
    }

    class Soldier
    {
        public string Name { get; private set; }

        public Soldier(string name)
        {
            Name = name;
        }
    }
}
