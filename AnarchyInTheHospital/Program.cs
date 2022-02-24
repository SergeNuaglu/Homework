using System;
using System.Collections.Generic;
using System.Linq;

namespace AnarchyInTheHospital
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.Work();
        }
    }

    class Hospital
    {       
        private List<Patient> _patients = new List<Patient>();

        public void Work()
        {
            bool isWork = true;
            int operationCount = 4;
            int operationNumber;

            CompleteTheList();
           
            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("Больные:");
                ShowAllPatients(_patients);
                Console.WriteLine("\nСортировка больных:");
                Console.WriteLine($"1 - сортировка по ФИО\n2 - сортировка по возрасту\n" +
                    $"3 - вывести больных с определенным заболеванием\n4 - выйти");
                Console.Write("Введите номер операции: ");

                if (int.TryParse(Console.ReadLine(), out operationNumber) && operationNumber > 0 && operationNumber <= operationCount)
                {
                    switch (operationNumber)
                    {
                        case 1:
                            Sort(operationNumber);
                            break;
                        case 2:
                            Sort(operationNumber);
                            break;
                        case 3:
                            SearchByDisease();
                            break;
                        case 4:
                            isWork = false; ;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nНет операции под таким номером");
                }
                Console.ReadKey();
            }
        }

        private void CompleteTheList()
        {
            _patients.Add(new Patient("Сухов Артем Васильевич", 45, "перелом"));
            _patients.Add(new Patient("Тарасов Леопольд Богданович", 24, "гепатит"));
            _patients.Add(new Patient("Борисенко Артур Юхимович", 56, "грипп"));
            _patients.Add(new Patient("Чухрай Игнатий Дмитриевич", 34, "аппендицит"));
            _patients.Add(new Patient("Дюбуа Огюст Жакович", 40, "грипп"));
            _patients.Add(new Patient("Ришар Марсель Кристианович", 17, "гепатит"));
            _patients.Add(new Patient("Горбунов Оливер Виталиевич", 29, "перелом"));
            _patients.Add(new Patient("Бекмамбетов Адиль Сабуров", 67, "аппендицит"));
            _patients.Add(new Patient("Башиев Шамиль Салманович", 54, "язва"));
            _patients.Add(new Patient("Кац Исаак Абрамович", 56, "язва"));
        }

        private void ShowAllPatients(List<Patient> patients)
        {
            Console.WriteLine();

            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.FullName}/ Возраст: {patient.Age}, Болезнь: {patient.Disease}");
            }
        }

        private void Sort(int operationNumber)
        {
            List<Patient> filteredPatients = new List<Patient>();

            switch (operationNumber)
            {
                case 1:
                    filteredPatients = _patients.OrderBy(patients => patients.FullName).ToList();
                    break;
                case 2:
                    filteredPatients = _patients.OrderBy(patients => patients.Age).ToList();
                    break;
            }

            ShowAllPatients(filteredPatients);
        }

        private void SearchByDisease()
        {
            string userInput;

            Console.Write("Введите название болезни: ");
            userInput = Console.ReadLine();
            var filteredPatients = _patients.Where(patients => patients.Disease.ToLower() == userInput.ToLower()).ToList();

            if (filteredPatients.Count == 0)
            {
                Console.WriteLine("Поиск не дал результатов");
            }
            else
            {
                ShowAllPatients(filteredPatients);
            }
        }
    }

    class Patient
    {
        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Patient(string fullName, int age, string disease)
        {
            FullName = fullName;
            Age = age;
            Disease = disease;
        }
    }
}
