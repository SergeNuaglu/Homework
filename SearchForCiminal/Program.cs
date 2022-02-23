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
        private bool _isSearch;
        List<Criminal> _criminals = new List<Criminal>();

        public void Work()
        {
            _isSearch = true;
            CompleteTheList();

            while (_isSearch)
            {
                if (_criminals == null)
                {
                    _criminals = new List<Criminal>();
                    CompleteTheList();
                }

                Console.Clear();
                Console.WriteLine("Преступники:\n");
                ShowAllCriminals();
                FilterSearch();
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
            foreach (var criminal in _criminals)
            {
                Console.WriteLine($"{criminal.FullName}, {criminal.Nationality}, Рост: {criminal.Height}, Вес: {criminal.Weight}");
            }
        }

        private void FilterSearch()
        {
            int operationNumber;
            float minHeight = 0;
            float maxHeight = 0;
            float minWeight = 0;
            float maxWeight = 0;

            Console.WriteLine("\nФильтр:");
            Console.WriteLine("Рост - 1\nВес - 2\nНациональность - 3\nСбросить все настройки - 4\nВыйти - 5");
            Console.Write("\nВведите номер операции: ");

            if (int.TryParse(Console.ReadLine(), out operationNumber))
            {
                switch (operationNumber)
                {
                    case 1:
                        DefineParameters(operationNumber, minHeight, maxHeight);
                        break;
                    case 2:
                        DefineParameters(operationNumber, minWeight, maxWeight);
                        break;
                    case 3:
                        FilterByNationality();
                        break;
                    case 4:
                        _criminals = null;
                        break;
                    case 5:
                        _isSearch = false; ;
                        break;
                }
            }
        }

        private void DefineParameters(int operationNumber, float minParameter, float maxParameter)
        {
            Console.Write("Минимальный параметр: ");

            if (Single.TryParse(Console.ReadLine(), out minParameter))
            {
                Console.Write("Максимальный параметр: ");

                if (Single.TryParse(Console.ReadLine(), out maxParameter))
                {
                    FilterByParameters(operationNumber, minParameter, maxParameter);
                }
            }
        }

        private void FilterByParameters(int operationNumber, float minParameter, float maxParameter)
        {
            switch (operationNumber)
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
