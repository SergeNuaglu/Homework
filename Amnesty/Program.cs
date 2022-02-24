using System;
using System.Collections.Generic;
using System.Linq;

namespace Amnesty
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Prisoner> prisoners = new List<Prisoner>();

            prisoners.Add(new Prisoner("Мельницкий Алексей Викторович", "Мошенничество"));
            prisoners.Add(new Prisoner("Остроухов Генадий Павлович", "Воровство"));
            prisoners.Add(new Prisoner("Каровин Иван Николаевич", "Антиправительственное"));
            prisoners.Add(new Prisoner("Таблеткин Петр Сергеевич", "Антиправительственное"));
            prisoners.Add(new Prisoner("Ефимов Николай Артемьевич", "Наркоторговля"));
            prisoners.Add(new Prisoner("Саитов Илья Михаилович", "Воровство"));
            prisoners.Add(new Prisoner("Троцкий Михаил Иванович", "Антиправительственное"));
            prisoners.Add(new Prisoner("Колбасов Антон Тарасович", "Антиправительственное"));
            prisoners.Add(new Prisoner("Сидоров Николай Петрович", "Мошенничество"));
            prisoners.Add(new Prisoner("Тарасенко Владислав Константинович", "Антиправительственное"));

            Console.WriteLine("Заключенные до амнистии:\n");
            ShowAllPrisoners(prisoners);
            prisoners = prisoners.OrderBy(prisoner => prisoner.Crime).SkipWhile(prisoner => prisoner.Crime.StartsWith("А")).ToList();
            Console.WriteLine("\nЗаключенные после амнистии:\n");
            ShowAllPrisoners(prisoners);
            Console.ReadKey();
            
        }

        public static void ShowAllPrisoners(List<Prisoner> prisoners)
        {
            foreach (var prison in prisoners)
            {
                Console.WriteLine(prison.FullName +", преступление: "+ prison.Crime);
            }
        }
    }

    class Prisoner
    {
        public string FullName { get; private set; }
        public string Crime { get; private set; }

        public Prisoner(string fullName, string crime)
        {
            FullName = fullName;
            Crime = crime;
        }
    }
}