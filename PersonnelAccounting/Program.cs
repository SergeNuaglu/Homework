using System;

namespace PersonnelAccounting
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] fullNames = new string[0];
            string[] positions = new string[0];
            string fullName;
            string position;
            string userInput;
            bool isAppWorking = true;

            while (isAppWorking)
            {
                Console.Clear();
                Console.WriteLine("1 - добавить досье\n\n2 - вывести все досье\n\n" +
                    "3 - удалить досье\n\n4 - поиск по фамилии\n\n5 - выход\n");
                Console.Write("Введите номер операции: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDossier(ref fullNames, ref positions, out fullName, out position);
                        break;
                    case "2":
                        OutputDossiers(fullNames, positions);
                        break;
                    case "3":
                        DeleteDossier(ref fullNames, ref positions);
                        break;
                    case "4":
                        Console.WriteLine(SearchByLastname(fullNames, positions));
                        break;
                    case "5":
                        isAppWorking = false;
                        break;
                }

                Console.ReadKey();
            }
        }

        static void AddDossier(ref string[] fullNames, ref string[] positions, out string fullName, out string position)
        {
            Console.Write("ФИО: ");
            fullName = Console.ReadLine();
            Console.Write("Должность: ");
            position = Console.ReadLine();

            if (fullNames == null)
            {
                fullNames[0] = fullName;
                positions[0] = position;
            }
            else
            {
                string[] tempFullNames = new string[fullNames.Length + 1];
                string[] tempPositions = new string[fullNames.Length + 1];

                for (int i = 0; i < fullNames.Length; i++)
                {
                    tempFullNames[i] = fullNames[i];
                    tempPositions[i] = positions[i];
                }

                tempFullNames[tempFullNames.Length - 1] = fullName;
                fullNames = tempFullNames;
                tempPositions[tempPositions.Length - 1] = position;
                positions = tempPositions;
            }
        }

        static void OutputDossiers(string[] fullNames, string[] positions)
        {
            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.Write(" {0}) {1} - {2}", i + 1, fullNames[i], positions[i]);
            }
        }

        static void DeleteDossier(ref string[] fullNames, ref string[] positions)
        {
            Console.Write("Номер досье: ");
            int dossierNumber = Convert.ToInt32(Console.ReadLine());

            for (int i = dossierNumber - 1; i < fullNames.Length - 1; i++)
            {
                fullNames[i] = fullNames[i + 1];
                positions[i] = positions[i + 1];
            }

            string[] tempFullNames = new string[fullNames.Length - 1];
            string[] tempPositions = new string[fullNames.Length - 1];

            for (int i = 0; i < tempFullNames.Length; i++)
            {
                tempFullNames[i] = fullNames[i];
                tempPositions[i] = positions[i];
            }

            fullNames = tempFullNames;
            positions = tempPositions;
        }

        static string SearchByLastname(string[] fullNames, string[] positions)
        {
            Console.Write("Фамилия: ");
            string lastname = Console.ReadLine();
            string dossier = "";

            for (int i = 0; i < fullNames.Length; i++)
            {
                if (fullNames[i].ToLower().Contains(lastname.ToLower()))
                {
                    dossier += (i + 1) + ") " + fullNames[i] + " - " + positions[i] + " ";
                }
            }
            return dossier;
        }
    }
}
