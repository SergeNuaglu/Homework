using System;

namespace PersonnelAccounting
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] fullNames = new string[0];
            string[] positions = new string[0];
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
                        AddDossier(ref fullNames, ref positions);
                        break;
                    case "2":
                        OutputDossiers(fullNames, positions);
                        break;
                    case "3":
                        DeleteDossier(ref fullNames, ref positions);
                        break;
                    case "4":
                        SearchByLastname(fullNames, positions);
                        break;
                    case "5":
                        isAppWorking = false;
                        break;
                }

                Console.ReadKey();
            }
        }

        static void AddDossier(ref string[] fullNames, ref string[] positions)
        {           
            Console.Write("ФИО: ");
            string fullName = Console.ReadLine();
            AddDossier(ref fullNames, fullName);
            Console.Write("Должность: ");
            string position = Console.ReadLine();
            AddDossier(ref positions, position);
        }

        static void AddDossier(ref string []array, string value)
        {
            if (array == null)
            {
                array[0] = value;
            }
            else
            {
                string[] tempFullNames = new string[array.Length + 1];

                for (int i = 0; i < array.Length; i++)
                {
                    tempFullNames[i] = array[i];
                }

                tempFullNames[tempFullNames.Length - 1] = value;
                array = tempFullNames;
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
            DeleteDossier(ref fullNames, dossierNumber);
            DeleteDossier(ref positions, dossierNumber);
        }

       static void DeleteDossier(ref string [] array, int number)
        {
            for (int i = number - 1; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = array[i];
            }

            array = tempArray;
        }

        static void SearchByLastname(string[] fullNames, string[] positions)
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
            Console.WriteLine(dossier);
        }
    }
}