using System;
using System.Collections.Generic;
using System.Linq;

namespace UnificationOfTroops
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Soldier> squadA = new List<Soldier>();
            List<Soldier> squadB = new List<Soldier>();

            squadA.Add(new Soldier("Сухаркин В.И"));
            squadA.Add(new Soldier("Загидулин М.Р"));
            squadA.Add(new Soldier("Кидалов Ю.О"));
            squadA.Add(new Soldier("Хамюк В.А."));
            squadA.Add(new Soldier("Стоянов Т.К."));
            squadA.Add(new Soldier("Хвалебин Р.Д."));
            squadA.Add(new Soldier("Угрюмов Б.К."));
            squadB.Add(new Soldier("Басов Н.Л."));
            squadB.Add(new Soldier("Самохвал Д.С."));
            squadB.Add(new Soldier("Черный С.С."));
            squadB.Add(new Soldier("Быков Б.К."));
            squadB.Add(new Soldier("Гонда Н.Л."));
            squadB.Add(new Soldier("Бочкин Д.С."));
            squadB.Add(new Soldier("Черногуб С.С."));
            squadA = squadA.Union(squadB.Where(soldier => soldier.Name.StartsWith("Б"))).ToList();
            squadB = squadB.OrderBy(soldier => soldier.Name).SkipWhile(soldier => soldier.Name.StartsWith("Б")).ToList();
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
