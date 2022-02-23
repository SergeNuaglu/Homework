using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchForCiminal
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            СriminalSearch criminalSearch = new СriminalSearch();
            criminalSearch.Work();
        }
    }

    class СriminalSearch
    {
        List<Criminal> _criminals = new List<Criminal>();

        public void Work()
        {
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                CompleteTheList();
                Console.WriteLine("Преступники:\n");
                ShowAllCriminals();
                FilterSearch();
                ShowAllCriminals();
                Console.ReadKey();
            }
        }

        private void CompleteTheList()
        {
            _criminals.Add(new Criminal("Сухов Артем Васильевич", "русский", 180, 95, true));
            _criminals.Add(new Criminal("Тарасов Леопольд Богданович", "русский", 180, 79, false));
            _criminals.Add(new Criminal("Борисенко Артур Юхимович", "украинец", 168, 68, true));
            _criminals.Add(new Criminal("Чухрай Игнатий Дмитриевич", "украинец", 175, 91, false));
            _criminals.Add(new Criminal("Дюбуа Огюст Жакович", "француз", 165, 68, true));
            _criminals.Add(new Criminal("Ришар Марсель Кристианович", "француз", 185, 100, false));
            _criminals.Add(new Criminal("Горбунов Оливер Виталиевич", "серб", 179, 80, false));
            _criminals.Add(new Criminal("Бекмамбетов Адиль Сабуров", "казах", 170, 74, false));
            _criminals.Add(new Criminal("Башиев Шамиль Салманович", "чеченец", 160, 90, false));
            _criminals.Add(new Criminal("Кац Исаак Абрамович", "еврей", 165, 75, false));
        }

        private void ShowAllCriminals()
        {
            if (_criminals.Count == 0)
            {
                Console.WriteLine("В базе данных нет преступника с указанными параметрами");
            }
            foreach (var criminal in _criminals)
            {
                Console.WriteLine($"{criminal.FullName}, {criminal.Nationality}, Рост: {criminal.Height}, Вес: {criminal.Weight}");
            }
        }

        private void FilterSearch()
        {
            bool isFilter = true;
            int stepNumber = 1;
            float minHeight = 0;
            float maxHeight = 0;
            float minWeight = 0;
            float maxWeight = 0;

            Console.WriteLine("\nПоиск преступников:");

            while (isFilter)
            {
                switch (stepNumber)
                {
                    case 1:
                        DefineParameters(ref stepNumber, minHeight, maxHeight);
                        break;
                    case 2:
                        DefineParameters(ref stepNumber, minWeight, maxWeight);
                        break;
                    case 3:
                        FilterByNationality();
                        break;
                    case 4:
                        isFilter = false;
                        break;
                }

                stepNumber++;
            }
        }

        private void DefineParameters(ref int stepNumber, float minParameter, float maxParameter)
        {
            string heightParameter = "рост";
            string weightParameter = "вес";
            string parameter = "";

            if (stepNumber == 1)
            {
                parameter = heightParameter;
            }
            else if (stepNumber == 2)
            {
                parameter = weightParameter;
            }

            Console.Write($"Минимальный {parameter} преступника: ");

            if (Single.TryParse(Console.ReadLine(), out minParameter))
            {
                Console.Write($"Максимальный {parameter} преступника: ");

                if (Single.TryParse(Console.ReadLine(), out maxParameter))
                {
                    FilterByParameters(stepNumber, minParameter, maxParameter);
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                    stepNumber--;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
                stepNumber--;
            }

            Console.WriteLine();
        }

        private void FilterByParameters(int stepNumber, float minParameter, float maxParameter)
        {
            switch (stepNumber)
            {
                case 1:
                    _criminals = _criminals.Where(criminal => criminal.Height >= minParameter && criminal.Height <= maxParameter && criminal.IsPrisoner == false).ToList();
                    break;
                case 2:
                    _criminals = _criminals.Where(criminal => criminal.Weight >= minParameter && criminal.Weight <= maxParameter && criminal.IsPrisoner == false).ToList();
                    break;
            }
        }

        private void FilterByNationality()
        {
            string userInput;

            Console.Write("Введите национальность преступника: ");
            userInput = Console.ReadLine();
            _criminals = _criminals.Where(criminal => criminal.Nationality.ToLower() == userInput.ToLower() && criminal.IsPrisoner == false).ToList();
            Console.WriteLine();
        }
    }

    class Criminal
    {
        public string FullName { get; private set; }
        public string Nationality { get; private set; }
        public float Height { get; private set; }
        public float Weight { get; private set; }
        public bool IsPrisoner { get; private set; }

        public Criminal(string fullName, string nationality, float height, float weight, bool isPrisoner)
        {
            FullName = fullName;
            Nationality = nationality;
            Height = height;
            Weight = weight;
            IsPrisoner = isPrisoner;
        }
    }
}
