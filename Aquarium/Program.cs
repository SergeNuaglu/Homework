using System;
using System.Collections.Generic;

namespace Aquarium
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Aquarium aquarium;
            Dictionary<string, int> fishTypes = new Dictionary<string, int>();

            fishTypes.Add("Goldfish", 12);
            fishTypes.Add("Guppy", 3);
            fishTypes.Add("Angelfish", 10);
            fishTypes.Add("Rainbowfish", 7);
            fishTypes.Add("ZebraDanio", 5);
            aquarium = new Aquarium(fishTypes);
            aquarium.Work();
        }
    }

    class Aquarium
    {
        private Dictionary<int, Fish> _fishes = new Dictionary<int, Fish>();
        private Dictionary<string, int> _fishTypes = new Dictionary<string, int>();

        public Aquarium(Dictionary<string, int> fishTypes)
        {
            _fishTypes = fishTypes;
        }

        public void Work()
        {
            int aquariumСapacity = 10;
            int timeCounter = 0;
            int userInput;
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"Прошло лет с запуска аквариума: {timeCounter}\n" +
                    $"Количество рыбок - {_fishes.Count}");
                Console.WriteLine("\nАКВАРИУМ");
                ShowAllFishes();
                Console.SetCursorPosition(0, 15);
                Console.WriteLine("Добвавить рыбку в аквариум - 1" +
                    "\nДостать рыбку из аквариума - 2");
                Console.Write("\nВведите номер операции: ");

                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    if (userInput == 1)
                    {
                        if (_fishes.Count < aquariumСapacity)
                        {
                            AddFish(timeCounter, aquariumСapacity);
                        }
                        else
                        {
                            Console.WriteLine("Аквариум уже есть допустимое количество рыбок");
                        }
                    }
                    else if (userInput == 2)
                    {
                        TakeFishOut();
                    }
                }

                for (int i = 1; i <= _fishes.Count; i++)
                {
                    if (_fishes.ContainsKey(i))
                    {
                        if (_fishes[i].GrowOld(timeCounter) <= 0)
                        {
                            Renumber(i);
                        }
                    }
                }

                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadKey();
                timeCounter++;
            }
        }

        private void ShowAllFishes()
        {
            if (_fishes.Count > 0)
            {
                foreach (var fish in _fishes)
                {
                    Console.Write($"{fish.Key}) ");
                    fish.Value.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("Пока что аквариум пуст...");
            }
        }

        private void AddFish(int timeOfBirth, int aquariumСapacity)
        {
            int fishesCount = 0;
            string fishType = "";
            int lifeTime = 0;
            int typeNumber = 0;

            Console.Clear();
            ChooseTypeOfFish(ref fishType, ref lifeTime, ref typeNumber);
            Console.WriteLine($"\nВы можете добавить {aquariumСapacity - _fishes.Count} рыбок");
            Console.Write("Введите количество рыбок: ");

            if (int.TryParse(Console.ReadLine(), out fishesCount) && fishesCount > 0 && fishesCount <= aquariumСapacity - _fishes.Count)
            {
                for (int i = 1; i <= fishesCount; i++)
                {
                    switch (typeNumber)
                    {
                        case 1:
                            _fishes.Add(_fishes.Count + 1, new Goldfish(fishType, lifeTime, timeOfBirth));
                            break;
                        case 2:
                            _fishes.Add(_fishes.Count + 1, new Guppy(fishType, lifeTime, timeOfBirth));
                            break;
                        case 3:
                            _fishes.Add(_fishes.Count + 1, new Angelfish(fishType, lifeTime, timeOfBirth));
                            break;
                        case 4:
                            _fishes.Add(_fishes.Count + 1, new Rainbowfish(fishType, lifeTime, timeOfBirth));
                            break;
                        case 5:
                            _fishes.Add(_fishes.Count + 1, new ZebraDanio(fishType, lifeTime, timeOfBirth));
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }
        }

        private void ChooseTypeOfFish(ref string fishType, ref int lifeTime, ref int typeNumber)
        {
            int iterationNumber = 1;

            ShowFishTypes();
            Console.Write("\nВведите номер рыбки: ");
            if (int.TryParse(Console.ReadLine(), out typeNumber))
            {
                if (typeNumber > 0 && typeNumber <= _fishTypes.Count)
                {
                    foreach (var type in _fishTypes)
                    {
                        if (iterationNumber++ == typeNumber)
                        {
                            fishType = type.Key;
                            lifeTime = type.Value;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Нет рыбки под таким номером");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }
        }

        private void ShowFishTypes()
        {
            int fishNumber = 1;

            Console.WriteLine("Рыбки, которые можно добавлять в аквариум:\n");

            foreach (var fishType in _fishTypes)
            {
                Console.WriteLine($"{fishNumber++} - {fishType.Key}, продолжительность жизни: {fishType.Value}");
            }

            Console.WriteLine();
        }

        private void TakeFishOut()
        {
            int fishNumber;

            Console.Write("Введите номер рыбки: ");

            if (int.TryParse(Console.ReadLine(), out fishNumber))
            {
                Renumber(fishNumber);
            }
            else
            {
                Console.WriteLine("Рыбки под таким номером нет в аквариуме");
            }
        }

        private void Renumber(int remoteFishNumber)
        {
            for (int i = 0; i <= _fishes.Count; i++)
            {
                _fishes.Remove(remoteFishNumber);

                if (_fishes.ContainsKey(remoteFishNumber + 1))
                {
                    _fishes.Add(remoteFishNumber, _fishes[remoteFishNumber++ + 1]);
                }
            }
        }

        class Fish
        {
            private string _type;
            private int _age;
            private int _timeOfBirth;

            public int LifeTime { get; private set; }

            public Fish(string fishType, int lifeTime, int timeOfBirth)
            {
                _type = fishType;
                LifeTime = lifeTime;
                _timeOfBirth = timeOfBirth;
            }

            public int GrowOld(int time)
            {
                return _age = LifeTime - time + _timeOfBirth;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"рыбка {_type}, возраст - {_age}");
            }
        }

        class Goldfish : Fish
        {
            public Goldfish(string type, int lifeTime, int timeOfBirth) : base(type, lifeTime, timeOfBirth) { }
        }

        class Guppy : Fish
        {
            public Guppy(string type, int lifeTime, int timeOfBirth) : base(type, lifeTime, timeOfBirth) { }
        }

        class Angelfish : Fish
        {
            public Angelfish(string type, int lifeTime, int timeOfBirth) : base(type, lifeTime, timeOfBirth) { }
        }

        class Rainbowfish : Fish
        {
            public Rainbowfish(string type, int lifeTime, int timeOfBirth) : base(type, lifeTime, timeOfBirth) { }
        }

        class ZebraDanio : Fish
        {
            public ZebraDanio(string type, int lifeTime, int timeOfBirth) : base(type, lifeTime, timeOfBirth) { }
        }
    }
}