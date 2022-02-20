using System;
using System.Collections.Generic;

namespace Aquarium
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int startingTime = 0;

            Aquarium aquarium = new Aquarium(startingTime);
            aquarium.Work();
        }
    }

    class Aquarium
    {
        private Dictionary<int, Fish> _fishes = new Dictionary<int, Fish>();
        private List<FishTypes> _fishTypes = new List<FishTypes>();

        public int TimeCounter;

        public Aquarium(int startingTime)
        {
            TimeCounter = startingTime;
        }

        enum FishTypes
        {
            Goldfish = 1,
            Guppy,
            Angelfish,
            Rainbowfish,
            ZebraDanio
        }

        public void Work()
        {
            int aquariumСapacity = 10;
            int userInput;
            bool isWork = true;

            _fishTypes.Add(FishTypes.Goldfish);
            _fishTypes.Add(FishTypes.Guppy);
            _fishTypes.Add(FishTypes.Angelfish);
            _fishTypes.Add(FishTypes.Rainbowfish);
            _fishTypes.Add(FishTypes.ZebraDanio);

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"Прошло времени с запуска аквариума: {TimeCounter}\n" +
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
                            Console.WriteLine($"\nВы можете добавить {aquariumСapacity - _fishes.Count} рыбок");
                            ChooseTypeOfFish();
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

                ChangeFishAge(TimeCounter);
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadKey();
                TimeCounter++;
            }
        }
        private void ChangeFishAge(int time)
        {
            for (int i = 1; i <= _fishes.Count; i++)
            {
                if (_fishes.ContainsKey(i))
                {
                    _fishes[i].GrowOld(time);

                    if (IsFishDied())
                    {
                        _fishes.Remove(i);
                        Renumber(i);
                    }
                }
            }
        }

        private bool IsFishDied()
        {
            for (int i = 1; i <= _fishes.Count; i++)
            {
                if (_fishes[i].Age == _fishes[i].LifeTime)
                {

                    return true;
                }
            }

            return false;
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

        private void ChooseTypeOfFish()
        {
            int typeNumber;

            ShowFishTypes();

            Console.Write("\nВведите номер рыбки: ");

            if (int.TryParse(Console.ReadLine(), out typeNumber))
            {
                if (typeNumber > 0 && typeNumber <= _fishTypes.Count)
                {
                    FishTypes fishType = _fishTypes[typeNumber - 1];
                    AddFish(fishType);
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

        private void AddFish(FishTypes fishType)
        {
            switch (fishType)
            {
                case FishTypes.Goldfish:
                    _fishes.Add(_fishes.Count + 1, new Goldfish(fishType, TimeCounter));
                    break;
                case FishTypes.Guppy:
                    _fishes.Add(_fishes.Count + 1, new Guppy(fishType, TimeCounter));
                    break;
                case FishTypes.Angelfish:
                    _fishes.Add(_fishes.Count + 1, new Angelfish(fishType, TimeCounter));
                    break;
                case FishTypes.Rainbowfish:
                    _fishes.Add(_fishes.Count + 1, new Rainbowfish(fishType, TimeCounter));
                    break;
                case FishTypes.ZebraDanio:
                    _fishes.Add(_fishes.Count + 1, new ZebraDanio(fishType, TimeCounter));
                    break;
            }
        }

        private void ShowFishTypes()
        {
            Console.WriteLine("Рыбки, которые можно добавлять в аквариум:\n");

            foreach (var type in _fishTypes)
            {
                Console.WriteLine($"{(int)type}) {type}");
            }
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
            private FishTypes _type;
            private int _timeOfBirth;

            public int Age { get; private set; }

            public int LifeTime { get; private set; }

            public Fish(FishTypes type, int timeOfBirth, int lifeTime)
            {
                _type = type;
                _timeOfBirth = timeOfBirth;
                LifeTime = lifeTime;
            }

            public void GrowOld(int time)
            {
                Age = time - _timeOfBirth;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"рыбка {_type}, возраст - {Age}, живет до {LifeTime}");
            }
        }

        class Goldfish : Fish
        {
            public Goldfish(FishTypes type, int timeOfBirth) : base(type, timeOfBirth, 12) { }
        }

        class Guppy : Fish
        {
            public Guppy(FishTypes type, int timeOfBirth) : base(type, timeOfBirth, 3) { }
        }

        class Angelfish : Fish
        {
            public Angelfish(FishTypes type, int timeOfBirth) : base(type, timeOfBirth, 10) { }
        }

        class Rainbowfish : Fish
        {
            public Rainbowfish(FishTypes type, int timeOfBirth) : base(type, timeOfBirth, 7) { }
        }

        class ZebraDanio : Fish
        {
            public ZebraDanio(FishTypes type, int timeOfBirth) : base(type, timeOfBirth, 5) { }
        }
    }
}