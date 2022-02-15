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
        private Train _train = new Train();
        private string _direction;
        private int _soldTicketCount;
        private int _placesLeftToFind;
        private int _stepNumber;
        private bool _isReadySend;

        public TrainConfigurator(Queue<string> directions)
        {
            _directions = directions;
        }

        public void Work()
        {
            bool isWork = true;
            _stepNumber = 1;

            while (isWork)
            {
                if (_stepNumber == 5)
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
                        _stepNumber = 1;
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
                   $"Направление - {_direction}\n" +
                   $"Продано билетов - {_soldTicketCount}\n" +
                   $"Осталось разместить - {_placesLeftToFind}\n" +
                   $"Состав поезда - ");

                if (_train.Carriages != null)
                {
                    foreach (var carriage in _train.Carriages)
                    {
                        Console.Write($"({carriage.Name}/Число пассажиров: {carriage.PlaceCount})-");
                    }
                }

                Console.SetCursorPosition(0, 7);
                Console.WriteLine($"Шаг №{_stepNumber}\n");
                Console.SetCursorPosition(0, 8);

                switch (_stepNumber)
                {
                    case 1:
                        CreateDirection();
                        break;
                    case 2:
                        SellTickets();
                        break;
                    case 3:
                        CreatedTrain();
                        break;
                    case 4:
                        SendTrain();
                        break;
                }

                _stepNumber++;
            }
        }

        private void CreateDirection()
        {
            string startingPlace;
            string endPlace;

            Console.Write("Введите пункт отправления: ");
            startingPlace = Console.ReadLine();

            if (_directions.Contains(startingPlace))
            {
                Console.Write("Введите пункт назначения: ");
                endPlace = Console.ReadLine();

                if (_directions.Contains(endPlace) && endPlace != startingPlace)
                {
                    _direction = startingPlace + " - " + endPlace;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                    Console.ReadKey();
                    _stepNumber--;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
                Console.ReadKey();
                _stepNumber--;
            }
        }

        private void SellTickets()
        {
            Random random = new Random();

            Console.WriteLine("Нажмите Enter, чтобы продать билеты на это направление");
            Console.ReadLine();
            _soldTicketCount = random.Next(100, 500);
            _placesLeftToFind = _soldTicketCount;
        }

        private void CreatedTrain()
        {
            Queue<Carriage> carriages = new Queue<Carriage>();
            bool isAttach = true;

            Console.WriteLine($"Осталось разместить пассажиров");

            Console.WriteLine("Вместительность вагонов:\n" +
                "Общий вагон, 81 место - 1\n" +
                "Плацкарт, 54 места - 2\n" +
                "СВ, 36 мест - 3\n");
            Console.Write("Введите номер, чтобы выбрать нужный вагон: ");

            switch (Console.ReadLine())
            {
                case "1":
                    carriages.Enqueue(new SeatingCar());
                    break;
                case "2":
                    carriages.Enqueue(new SleeperCar());
                    break;
                case "3":
                    carriages.Enqueue(new LuxeCar());
                    break;
                default:
                    isAttach = false;
                    break;
            }

            if (isAttach)
            {
                _placesLeftToFind -= carriages.Peek().PlaceCount;
                _train.AttachCarriage(carriages.Peek());
            }

            if (_placesLeftToFind > 0)
            {
                _stepNumber--;
            }
            else
            {
                _isReadySend = true;
            }
        }

        private void SendTrain()
        {
            if (_isReadySend)
            {
                Console.WriteLine("Нажмите Enter, чтобы отправить поезд");
                Console.ReadLine();
                _isReadySend = false;
            }

            System.Threading.Thread.Sleep(400);

            if (_train.Carriages.Count > 0)
            {
                _train.Carriages.Dequeue();
                _stepNumber--;
            }
            else
            {
                _direction = null;
                _soldTicketCount = 0;
                _placesLeftToFind = 0;
                Console.WriteLine("Поезд ушел.");
                Console.ReadLine();
            }
        }
    }

    class Train
    {
        private Queue<Carriage> _carriages = new Queue<Carriage>();
        public Queue<Carriage> Carriages
        {
            get
            {
                return _carriages;
            }
        }

        public Train() { }

        public Train(Queue<Carriage> carriages)
        {
            _carriages = carriages;
        }

        public void AttachCarriage(Carriage carriage)
        {
            _carriages.Enqueue(carriage);
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
