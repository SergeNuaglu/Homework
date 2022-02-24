using System;
using System.Collections.Generic;
using System.Linq;

namespace ArmsReport
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>();

            soldiers.Add(new Soldier("Сухаркин В.И", "АК-74М", "Младший сержант", 10));
            soldiers.Add(new Soldier("Загидулин М.Р", "Печенег", "Рядовой", 4));
            soldiers.Add(new Soldier("Кидалов Ю.О", "Корд", "Рядовой", 4));
            soldiers.Add(new Soldier("Хамюк В.А.", "СВ-98", "Рядовой", 3));
            soldiers.Add(new Soldier("Стоянов Т.К.", "РПГ-7", "Рядовой", 9));
            soldiers.Add(new Soldier("Хвалебин Р.Д.", "АК-74М", "Младший сержант", 9));
            soldiers.Add(new Soldier("Угрюмов Б.К.", "Печенег", "Рядовой", 10));
            soldiers.Add(new Soldier("Басов Н.Л.", "Корд", "Рядовой", 4));
            soldiers.Add(new Soldier("Самохвал Д.С.", "СВ-98", "Рядовой", 3));
            soldiers.Add(new Soldier("Черный С.С.", "РПГ-7", "Рядовой", 10));
            var newSoldiers = from Soldier soldier in soldiers
                              select new
                              {
                                  Name = soldier.Name,
                                  Rank = soldier.Rank
                              };
            newSoldiers.ToList();
            Console.WriteLine("Солдаты:\n");

            foreach (var soldier in newSoldiers)
            {
                Console.WriteLine(soldier.Name + "/ звание: " + soldier.Rank);
            }
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string Armament { get; private set; }
        public string Rank { get; private set; }
        public int TermOfService { get; private set; }

        public Soldier(string name, string armament, string rank, int termOfService)
        {
            Name = name;
            Armament = armament;
            Rank = rank;
            TermOfService = termOfService;
        }
    }
}
