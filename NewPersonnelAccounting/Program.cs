using System;
using System.Collections.Generic;

namespace PersonnelAccounting
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> dossiers = new Dictionary<string, string>();
            string[] fullNames = new string[0];
            string[] positions = new string[0];
            string userInput;
            bool isAppWorking = true;

            while (isAppWorking)
            {
                Console.Clear();
                Console.WriteLine("1 - добавить досье\n\n2 - вывести все досье\n\n" +
                    "3 - удалить досье\n\n4 - выход\n");
                Console.Write("Введите номер операции: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDossier(ref dossiers);
                        break;
                    case "2":
                        OutputDossiers(dossiers);
                        break;
                    case "3":
                        DeleteDossier(ref dossiers);
                        break;
                    case "4":
                        isAppWorking = false;
                        break;
                }

                Console.ReadKey();
            }
        }

        static void AddDossier(ref Dictionary<string, string> dossiers)
        {
            Console.Write("ФИО: ");
            string fullName = Console.ReadLine();
            Console.Write("Должность: ");
            string position = Console.ReadLine();
            dossiers.Add(fullName, position);
        }

        static void OutputDossiers(Dictionary<string, string> dossiers)
        {
            foreach (var dossier in dossiers)
            {
                Console.Write(dossier.Key + " - " + dossier.Value + " ");
            }
        }

        static void DeleteDossier(ref Dictionary<string,string> dossiers)
        {
            Console.Write("ФИО: ");
            string fullName = Console.ReadLine();

            if (dossiers.ContainsKey(fullName))
            {
                dossiers.Remove(fullName);
            }
        }
    }
}
