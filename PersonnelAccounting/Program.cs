using System;

namespace PersonnelAccounting
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] fullNames = new string[1];
            string[] positions = new string[1];
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
                        Console.Write("ФИО: ");
                        fullNames = AddDossier(fullNames, Console.ReadLine());
                        Console.Write("Должность: ");
                        positions = AddDossier(positions, Console.ReadLine());
                        break;
                    case "2":
                        OutputDossiers(fullNames, positions);
                        break;
                    case "3":
                        Console.Write("Номер досье: ");
                        int dossierNumber = Convert.ToInt32(Console.ReadLine());
                        fullNames = DeleteDossier(dossierNumber, fullNames);
                        positions = DeleteDossier(dossierNumber, positions);
                        break;
                    case "4":
                        Console.Write("Фамилия: ");
                        string lastname = Console.ReadLine();
                        Console.WriteLine(OutputDossiers(fullNames, positions, lastname));
                        Console.ReadKey();
                        break;
                    case "5":
                        isAppWorking = false;
                        break;
                }
            }
        }

        static string[] AddDossier(string[] array, string value)
        {
            if (array[0] == null)
            {
                array[0] = value;
                return array;
            }
            else
            {
                string[] tempArrey = new string[array.Length + 1];

                for (int i = 0; i < array.Length; i++)
                {
                    tempArrey[i] = array[i];
                }

                tempArrey[tempArrey.Length - 1] = value;

                return tempArrey;
            }
        }

        static void OutputDossiers(string[] fullNames, string[] positions)
        {
            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.Write(" {0}) {1} - {2}", i + 1, fullNames[i], positions[i]);
            }

            Console.ReadKey();
        }

        static string OutputDossiers(string[] fullNames, string[] positions, string lastname)
        {
            string dossier ="";

            for (int i = 0; i < fullNames.Length; i++)
            {
                if (fullNames[i].ToLower().Contains(lastname.ToLower()))
                {
                    dossier += (i+1) + ") " + fullNames[i] + " - " + positions[i] + " ";
                }
            }
            return dossier;
        }

        static string[] DeleteDossier(int dossierNumber, string[] array)
        {
            if (array.Length >= dossierNumber)
            {
                for (int i = dossierNumber - 1; i < array.Length; i++)
                {
                    if (i != array.Length - 1)
                    {
                        array[i] = array[i + 1];
                    }
                }

                string[] tempArray = new string[array.Length - 1];

                for (int i = 0; i < array.Length; i++)
                {
                    if (i < tempArray.Length)
                        tempArray[i] = array[i];
                }

                array = tempArray;
            }
            else
            {
                Console.WriteLine("Нет досье по такому номеру!");
            }

            return array;
        }
    }
}
