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
                        OutputDossiers(fullNames, positions, lastname);
                        break;
                    case "5":
                        isAppWorking = false;
                        break;
                }
            }
        }

        static string[] AddDossier(string[] arrey, string value)
        {
            if (arrey[0] == null)
            {
                arrey[0] = value;
                return arrey;
            }
            else
            {
                string[] tempArrey = new string[arrey.Length + 1];

                for (int i = 0; i < arrey.Length; i++)
                {
                    tempArrey[i] = arrey[i];
                    tempArrey[tempArrey.Length - 1] = value;
                }

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

        static void OutputDossiers(string[] fullNames, string[] positions, string lastname)
        {
            string fullName = "";

            for (int i = 0; i < fullNames.Length; i++)
            {
                for (int j = 0; fullNames[i][j] != ' '; j++)
                {       
                        fullName += fullNames[i][j];
 
                    if (fullName == lastname)
                    {
                        Console.Write("{0}) {1} - {2} ", i + 1, fullNames[i], positions[i]);
                        fullName = "";
                    }
                }               
            }
            Console.ReadKey();
        }

        static string[] DeleteDossier(int value, string[] arrey)
        {
            if (arrey.Length >= value)
            {
                for (int i = value - 1; i < arrey.Length; i++)
                {
                    if (i != arrey.Length - 1)
                    {
                        arrey[i] = arrey[i + 1];
                    }
                }

                string[] tempArrey = new string[arrey.Length - 1];

                for (int i = 0; i < arrey.Length; i++)
                {
                    if (i < tempArrey.Length)
                        tempArrey[i] = arrey[i];
                }

                arrey = tempArrey;
            }
            else
            {
                Console.WriteLine("Нет досье по такому номеру!");
            }

            return arrey;
        }
    }
}
