using System;
using System.Collections.Generic;

namespace Zoo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.Work();
        }
    }

    class Zoo
    {
        private List<Cage> _cages = new List<Cage>();

        public enum AnimalTypes
        {
            Lion,
            Elephant,
            Flamingo,
            Bear
        }

        public void Work()
        {
            bool isWork = true;
            string userInput;
            int cageNumber;

            CreateCages();

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("ЗООПАРК\n");
                ShowMenu();
                Console.Write("\nВведите номер вольера: ");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out cageNumber))
                {
                    if (cageNumber > 0 && cageNumber <= _cages.Count)
                    {
                        ShowCage(cageNumber);
                    }
                    else
                    {
                        Console.WriteLine("Нет вольера под таким номером");
                    }

                }
                else if (userInput == "exit")
                {
                    isWork = false;
                }
                else
                {
                    Console.WriteLine("Некоректный ввод");
                }

                Console.ReadKey();
            }
        }

        private void CreateCages()
        {
            Random random = new Random();
            int cageCapacity;
            int minCapacity = 3;
            int maxCapacity = 8;
            List<AnimalTypes> animalTypes = new List<AnimalTypes>();

            animalTypes.Add(AnimalTypes.Lion);
            animalTypes.Add(AnimalTypes.Elephant);
            animalTypes.Add(AnimalTypes.Flamingo);
            animalTypes.Add(AnimalTypes.Bear);

            foreach (var type in animalTypes)
            {
                cageCapacity = random.Next(minCapacity, maxCapacity);
                PutAnimalsInCage(type, cageCapacity);
            }
        }

        private void ShowCage(int cageNumber)
        {
            Console.Clear();
            Console.WriteLine($"Вольер №{cageNumber}\n\nКоличество животных - {_cages[cageNumber - 1].CageCapacity}");
            _cages[cageNumber - 1].ShowAnimals();
        }

        private void PutAnimalsInCage(AnimalTypes type, int cageCapacity)
        {
            List<Animal> animals = new List<Animal>();

            for (int j = 0; j < cageCapacity; j++)
            {
                switch (type)
                {
                    case AnimalTypes.Lion:
                        animals.Add(new Lion(type, GetAnimalGender()));
                        break;
                    case AnimalTypes.Elephant:
                        animals.Add(new Elephant(type, GetAnimalGender()));
                        break;
                    case AnimalTypes.Flamingo:
                        animals.Add(new Flamingo(type, GetAnimalGender()));
                        break;
                    case AnimalTypes.Bear:
                        animals.Add(new Bear(type, GetAnimalGender()));
                        break;
                }
            }

            _cages.Add(new Cage(animals, cageCapacity));
        }

        private string GetAnimalGender()
        {
            Random random = new Random();
            int maxNumber = 2;

            if (Convert.ToBoolean(random.Next(maxNumber)))
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }

        private void ShowMenu()
        {
            for (int i = 1; i <= _cages.Count; i++)
            {
                Console.WriteLine($"Вольер №{i}");
            }
            Console.WriteLine("Выйти - exit");
        }

    }

    class Cage
    {
        private List<Animal> _animals = new List<Animal>();

        public int CageCapacity { get; private set; }

        public Cage(List<Animal> animals, int cageCapacity)
        {
            _animals = animals;
            CageCapacity = cageCapacity;
        }

        public void ShowAnimals()
        {
            foreach (var animal in _animals)
            {
                animal.ShowInfo();
            }
        }
    }

    class Animal
    {
        private Zoo.AnimalTypes _type;
        private string _gender;
        private string _sound;

        public Animal(Zoo.AnimalTypes type, string gender, string sound)
        {
            _type = type;
            _gender = gender;
            _sound = sound;
        }

        public void ShowInfo()
        {
            Console.Write($"Вид: {_type} Пол: {_gender} Звук:{_sound}\n");
        }
    }

    class Lion : Animal
    {
        public Lion(Zoo.AnimalTypes type, string gender) : base(type, gender, "ROAR!") { }
    }

    class Elephant : Animal
    {
        public Elephant(Zoo.AnimalTypes type, string gender) : base(type, gender, "HONK!") { }
    }

    class Flamingo : Animal
    {
        public Flamingo(Zoo.AnimalTypes type, string gender) : base(type, gender, "QUACK!") { }
    }

    class Bear : Animal
    {
        public Bear(Zoo.AnimalTypes type, string gender) : base(type, gender, "GROWL!") { }
    }
}
