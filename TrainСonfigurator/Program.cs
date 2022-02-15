using System;
using System.Collections.Generic;

namespace TrainСonfigurator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            TrainConfigurator trainConfigurator;
            Queue<string> directions = new Queue<string>();

            directions.Enqueue("Каменные лбы");
            directions.Enqueue("Змеиный глаз");
            directions.Enqueue("Черное озеро");
            directions.Enqueue("Рябиновый остров");
            directions.Enqueue("Рыбий хребет");
            directions.Enqueue("Железные холмы");
            directions.Enqueue("Длинный берег");
            directions.Enqueue("Южный мыс");
            directions.Enqueue("Огненный бор");
            trainConfigurator = new TrainConfigurator(directions);
            trainConfigurator.Work();
        }
    }

    class TrainConfigurator
    {
        private Queue<string> _directions;

        public TrainConfigurator(Queue<string> directions)
        {
            _directions = directions;
        }

        public void Work()
        {
            Train train = new Train();
            bool isWork = true;
            bool isReadySend = true;
            string trainDirection = "";
            int soldTicketCount = 0;
            int stepNumber = 1;

            while (isWork)
            {
                if (stepNumber == 5)
                {
                    Console.Clear();
                    Console.Write("Нажмите Enter, чтобы сконфигурировать новый поезд.\n" +
                        "Введите exit, чтобы выйти: ");
                    if (Console.ReadLine() == "exit")
                    {
                        isWork = false;
                    }
                    else
                    {
                        trainDirection = "";
                        soldTicketCount = 0;
                        stepNumber = 1;
                    }
                }
                Console.Clear();
                Console.SetCursorPosition(0, 16);
                Console.WriteLine("Направления поездов:");

                foreach (var direction in _directions)
                {
                    Console.WriteLine(direction);
                }

                Console.SetCursorPosition(0, 0);
                Console.Write("Конфигуратор поездов запущен\n\n" +
                   $"Направление - {trainDirection}\n" +
                   $"Продано билетов - {soldTicketCount}\n" +
                   $"Состав поезда - ");

                if (train.GetCarriagesCount() != 0)
                {
                    train.ShowAllCarriage();
                }

                Console.SetCursorPosition(0, 7);
                Console.WriteLine($"Шаг №{stepNumber}\n");
                Console.SetCursorPosition(0, 8);

                switch (stepNumber)
                {
                    case 1:
                        trainDirection = CreateDirection(ref stepNumber);
                        break;
                    case 2:
                        soldTicketCount = SellTickets(ref stepNumber);
                        break;
                    case 3:
                        AddCarruage(train, ref stepNumber, soldTicketCount);
                        break;
                    case 4:
                        SendTrain(train, ref stepNumber, ref isReadySend);
                        break;
                }
            }
        }

        private string CreateDirection(ref int stepNumber)
        {
            string startingPlace;
            string endPlace;
            string direction = "";

            Console.Write("Введите пункт отправления: ");
            startingPlace = Console.ReadLine();

            if (_directions.Contains(startingPlace))
            {
                Console.Write("Введите пункт назначения: ");
                endPlace = Console.ReadLine();

                if (_directions.Contains(endPlace) && endPlace != startingPlace)
                {
                    direction = startingPlace + " - " + endPlace;
                    stepNumber++;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
                Console.ReadKey();
            }

            return direction;
        }

        private int SellTickets(ref int stepNumber)
        {
            Random random = new Random();
            int soldTicketCount;

            Console.WriteLine("Нажмите Enter, чтобы продать билеты на это направление");
            Console.ReadLine();
            soldTicketCount = random.Next(100, 500);
            stepNumber++;
            return soldTicketCount;
        }

        private void AddCarruage(Train train, ref int stepNumber, int soldTicketCount)
        {
            string userInput = "";
            SeatingCar seatingCar = new SeatingCar();
            SleeperCar sleeperCar = new SleeperCar();
            LuxeCar luxeCar = new LuxeCar();

            while (soldTicketCount > 0)
            { 
                Console.WriteLine($"Осталось разместить пассажиров: {soldTicketCount} ");
                Console.WriteLine("Вместительность вагонов:\n" +
                $"{seatingCar.Name}, количество мест {seatingCar.PlaceCount} - 1\n" +
                $"{sleeperCar.Name}, количество мест {sleeperCar.PlaceCount} - 2\n" +
                $"{luxeCar.Name},  количество мест {luxeCar.PlaceCount} - 3\n");

                Console.Write("Введите номер, чтобы выбрать нужный вагон: ");
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    train.AttachCarriage(seatingCar);
                    soldTicketCount -= seatingCar.PlaceCount;
                }
                else if (userInput == "2")
                {
                    train.AttachCarriage(sleeperCar);
                    soldTicketCount -= sleeperCar.PlaceCount;
                }
                else if (userInput == "3")
                {
                    train.AttachCarriage(luxeCar);
                    soldTicketCount -= luxeCar.PlaceCount;
                }

                Console.SetCursorPosition(0, 8);
            }

                stepNumber++;
        }

        private void SendTrain(Train train, ref int stepNumber, ref bool isReadySend)
        {
            if (isReadySend)
            {
                Console.WriteLine("Нажмите Enter, чтобы отправить поезд");
                Console.ReadLine();
                isReadySend = false;
            }

            System.Threading.Thread.Sleep(400);

            if (train.GetCarriagesCount() > 0)
            {
                train.DeleteFirstCarriage();
            }
            else
            {
                Console.WriteLine("Поезд ушел.");
                Console.ReadLine();
                stepNumber++;
            }
        }
    }

    class Train
    {
        private Queue<Carriage> _carriages = new Queue<Carriage>();

        public Train() { }

        public Train(Queue<Carriage> carriages)
        {
            _carriages = carriages;
        }

        public int GetCarriagesCount()
        {
            return _carriages.Count;
        }

        public void DeleteFirstCarriage()
        {
            _carriages.Dequeue();
        }

        public void AttachCarriage(Carriage carriage)
        {
            _carriages.Enqueue(carriage);
        }

        public void ShowAllCarriage()
        {
            foreach (var carriage in _carriages)
            {
                Console.Write($"({carriage.Name}/Число пассажиров: {carriage.PlaceCount})-");
            }
        }
    }

    class Carriage
    {
        public string Name { get; private set; }
        public int PlaceCount { get; private set; }

        public Carriage(string name, int placeCount)
        {
            Name = name;
            PlaceCount = placeCount;
        }

    }

    class SeatingCar : Carriage
    {
        public SeatingCar(string name = "Общий вагон", int placeCount = 81) : base(name, placeCount) { }
    }

    class SleeperCar : Carriage
    {
        public SleeperCar(string name = "Плацкарт", int placeCount = 54) : base(name, placeCount) { }
    }

    class LuxeCar : Carriage
    {
        public LuxeCar(string name = "СВ", int placeCount = 36) : base(name, placeCount) { }
    }
}
