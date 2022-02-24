using System;
using System.Collections.Generic;
using System.Linq;

namespace DefinitionOfOverdue
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int currentYear = 2022;
            List<CannedStew> cannedStews = new List<CannedStew>();

            cannedStews.Add(new CannedStew("Микоян", 2010, 5));
            cannedStews.Add(new CannedStew("Честный продукт", 2020, 6));
            cannedStews.Add(new CannedStew("Гродфуд", 2015, 4));
            cannedStews.Add(new CannedStew("Совок", 2012, 4));
            cannedStews.Add(new CannedStew("Барс", 2021, 3));
            cannedStews.Add(new CannedStew("Мяскон", 2005, 7));
            cannedStews.Add(new CannedStew("Атрус", 2008, 4));
            cannedStews.Add(new CannedStew("Вкусвилл", 2004, 8));
            cannedStews.Add(new CannedStew("Главпродукт", 2018, 5));
            cannedStews.Add(new CannedStew("Экспедиция", 2017, 6));
            Console.WriteLine("Весь набор тушенки:\n");
            ShowAllCannedStews(cannedStews);
            var overdueCannedStew = cannedStews.Where(cannedStew => cannedStew.ProductionYear + cannedStew.ExpirationDate <= currentYear).ToList();
            Console.WriteLine($"\nПросроченная тушенка:\n");
            ShowAllCannedStews(overdueCannedStew);
            Console.ReadKey();
        }

        public static void ShowAllCannedStews(List<CannedStew> cannedStews)
        {
            foreach (var cannedStew in cannedStews)
            {
                Console.WriteLine(cannedStew.Name + "/ год производства: " + cannedStew.ProductionYear + ", " +
                    "срок годности: " + cannedStew.ExpirationDate);
            }
        }
    }

    class CannedStew
    {
        public string Name { get; private set; }
        public int ProductionYear { get; private set; }
        public int ExpirationDate { get; private set; }

        public CannedStew(string name, int productionYear, int expirationDate)
        {
            Name = name;
            ProductionYear = productionYear;
            ExpirationDate = expirationDate;
        }
    }
}
