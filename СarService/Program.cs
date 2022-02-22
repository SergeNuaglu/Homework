using System;
using System.Collections.Generic;
using System.Linq;

namespace СarService
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            float startingMoney = 0f;
            List<CarDetail> details = new List<CarDetail>();

            details.Add(new Engine(300));
            details.Add(new Transmission(50));
            details.Add(new FuelPump(16));
            details.Add(new BrakeSystem(6));
            details.Add(new Wheel(130));
            details.Add(new Windshield(150));

            CarService carService = new CarService(new Warehouse(details), startingMoney);
            carService.Work();
        }
    }

    class CarService
    {
        private float _money;
        private float _priceForWork = 10;
        private Warehouse _warehouse;
        private Dictionary<Warehouse.Details, float> _priceList;
        private Queue<Car> _repairCars = new Queue<Car>();

        public CarService(Warehouse warehouse, float money)
        {
            _warehouse = warehouse;
            _money = money;
        }

        public void Work()
        {
            bool isWork = true;
            int operationNumber;
            int operationCount = 4;

            CreatePriceList();

            while (isWork)
            {
                Console.Clear();
                CreateCarsQueue();
                Console.WriteLine("АВТОСЕРВИС\n");
                Console.WriteLine($"Заработано: {_money}\n");
                Console.WriteLine("1 - Следующий автомобиль\n2 - Зайти на склад \n3 - Пополнить склад\n4 - Выйти\n");
                Console.Write("Введите номер операции: ");

                if (int.TryParse(Console.ReadLine(), out operationNumber) && operationNumber > 0 && operationNumber <= operationCount)
                {
                    switch (operationNumber)
                    {
                        case 1:
                            ServeClient();
                            break;
                        case 2:
                            _warehouse.ShowAllDetails();
                            break;
                        case 3:
                            FillWarehouse(_money);
                            break;
                        case 4:
                            isWork = false;
                            break;
                    }
                }

                if (IsMoney() == false)
                {
                    Console.WriteLine("Автосервис обанкротился...");
                    isWork = false;
                }

                Console.ReadKey();
            }
        }

        private void CreatePriceList()
        {
            _priceList = _warehouse.GetPrices();
        }

        private void CreateCarsQueue()
        {
            int minCarCount = 1;
            int maxCarCount = 3;
            Random random = new Random();
            int carCount;

            carCount = random.Next(minCarCount, maxCarCount);

            for (int i = 0; i < carCount; i++)
            {
                int detailIndex = random.Next(0, _priceList.Count);
                Warehouse.Details detail = _priceList.ElementAt(detailIndex).Key;
                _repairCars.Enqueue(new Car(detail));
            }
        }

        private void ServeClient()
        {
            float priceForRepair = 0;
            int operationNumber;

            DiagnoseNextCar(ref priceForRepair);
            Console.WriteLine("1 - Взяться за работу\n2 - Отказать клиенту");
            Console.Write("\nВведите номер операции: ");

            if (int.TryParse(Console.ReadLine(), out operationNumber))
            {
                if (operationNumber == 1)
                {
                    if (_warehouse.IsEmpty() == false)
                    {
                        if (IsFixedRight())
                        {
                            Console.WriteLine("\nМашина починена, клиент доволен!");
                            _money += priceForRepair;
                        }
                        else
                        {
                            PayDamages();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nСклад пустой, придется отказать клиенту и заплатить штраф");
                        PayFine();
                    }
                }
                else if (operationNumber == 2)
                {
                    Console.WriteLine("Пришлось заплатить штраф");
                    PayFine();
                }
            }
        }

        private void DiagnoseNextCar(ref float priceForRepair)
        {
            Console.Clear();
            Console.WriteLine($"Следующий клиент:\n" +
                $"В машине обнаружена неисправность. Это {_repairCars.Peek().BrokenDetail}");

            foreach (var item in _priceList)
            {
                if (item.Key == _repairCars.Peek().BrokenDetail)
                {
                    priceForRepair = item.Value + _priceForWork;
                    Console.WriteLine($"Цена за починку: {item.Value + _priceForWork}\n");
                }
            }
        }

        private bool IsFixedRight()
        {
            CarDetail detail = new CarDetail();

            _warehouse.ShowAllDetails();
            _warehouse.ChooseDetail(ref detail);

            if (detail.Name == _repairCars.Peek().BrokenDetail)
            {
                _repairCars.Dequeue();
                return true;
            }
            else
            {
                _repairCars.Dequeue();
                return false;
            }
        }

        private void PayDamages()
        {
            Random random = new Random();
            int damageAmount;
            int minDamageAmount = 50;
            int maxDamageAmount = 100;

            damageAmount = random.Next(minDamageAmount, maxDamageAmount);
            Console.WriteLine($"\nВы установили не ту деталь, теперь вам придется возместить ущерб в размере {damageAmount}");
            _money -= damageAmount;
        }

        private void PayFine()
        {
            int fineAmount = 100;

            Console.WriteLine($"\nРазмер штрафа - {fineAmount}");

            _money -= fineAmount;
            _repairCars.Dequeue();
        }

        private void FillWarehouse(float money)
        {
            int discount = 50;
            int maxPricePercent = 100;
            int productNumber = 1;
            bool isBuy = true;

            while (isBuy)
            {
                Console.Clear();
                Console.WriteLine("В магазине автозапчастей для автосервиса\n" +
                    $"закупочная цена состовляет {discount} процентов от розничной в автосервисе\n");

                foreach (var detail in _priceList)
                {
                    Console.WriteLine($"{productNumber}) {detail.Key}, цена для автосервиса: {detail.Value / 100 * 50}");
                    productNumber++;
                }

                Console.Write("\nВведите номер товара: ");

                if (int.TryParse(Console.ReadLine(), out productNumber) && productNumber > 0 && productNumber < _priceList.Count)
                {
                    if (money >= _priceList.ElementAt(productNumber - 1).Value)
                    {
                        _warehouse.BuyNewDetail(_priceList.ElementAt(productNumber - 1).Key, _priceList.ElementAt(productNumber - 1).Value);
                        _money -= _priceList.ElementAt(productNumber - 1).Value / maxPricePercent * discount;
                        isBuy = false;
                    }
                    else
                    {
                        Console.WriteLine("\nУ автосервиса недостаточно средств для покупки этой детали!");
                        isBuy = false;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
        }

        private bool IsMoney()
        {
            if (_money >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Warehouse
    {
        private List<CarDetail> _details = new List<CarDetail>();

        public Warehouse(List<CarDetail> details)
        {
            _details = details;
        }

        public enum Details
        {
            Engine,
            Transmission,
            FuelPump,
            BrakeSystem,
            Wheel,
            Windshield
        }

        public bool IsEmpty()
        {
            if (_details.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ChooseDetail(ref CarDetail detail)
        {
            int detailNumber;

            if (_details.Count > 0)
            {
                Console.Write("Введите номер необходимой для ремонта детали: ");

                if (int.TryParse(Console.ReadLine(), out detailNumber) && detailNumber > 0 && detailNumber <= _details.Count)
                {
                    detail = _details[detailNumber - 1];
                    _details.RemoveAt(detailNumber - 1);
                }
            }
            else
            {
                Console.WriteLine("Склад пустой!");
            }
        }

        public Dictionary<Details, float> GetPrices()
        {
            Dictionary<Details, float> priceList = new Dictionary<Details, float>();

            foreach (var detail in _details)
            {
                priceList.Add(detail.Name, detail.Price);
            }

            return priceList;
        }

        public void ShowAllDetails()
        {
            Console.Clear();
            Console.WriteLine("СКЛАД\n");

            for (int i = 0; i < _details.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_details[i].Name}");
            }

            Console.WriteLine();
        }

        public void BuyNewDetail(Details detail, float price)
        {

            switch (detail)
            {
                case Details.Engine:
                    _details.Add(new Engine(price));
                    break;
                case Details.Transmission:
                    _details.Add(new Transmission(price));
                    break;
                case Details.FuelPump:
                    _details.Add(new FuelPump(price));
                    break;
                case Details.BrakeSystem:
                    _details.Add(new BrakeSystem(price));
                    break;
                case Details.Wheel:
                    _details.Add(new Wheel(price));
                    break;
                case Details.Windshield:
                    _details.Add(new Windshield(price));
                    break;
            }
        }
    }

    class Car
    {
        public Warehouse.Details BrokenDetail { get; private set; }

        public Car(Warehouse.Details brokenDetail)
        {
            BrokenDetail = brokenDetail;
        }
    }

    class CarDetail
    {
        public Warehouse.Details Name { get; private set; }

        public float Price { get; private set; }

        public CarDetail() { }

        public CarDetail(Warehouse.Details name, float price)
        {
            Name = name;
            Price = price;
        }
    }

    class Engine : CarDetail
    {
        public Engine(float price) : base(Warehouse.Details.Engine, price) { }
    }

    class Transmission : CarDetail
    {
        public Transmission(float price) : base(Warehouse.Details.Transmission, price) { }
    }

    class FuelPump : CarDetail
    {
        public FuelPump(float price) : base(Warehouse.Details.FuelPump, price) { }
    }

    class BrakeSystem : CarDetail
    {
        public BrakeSystem(float price) : base(Warehouse.Details.BrakeSystem, price) { }
    }

    class Wheel : CarDetail
    {
        public Wheel(float price) : base(Warehouse.Details.Wheel, price) { }
    }

    class Windshield : CarDetail
    {
        public Windshield(float price) : base(Warehouse.Details.Windshield, price) { }
    }
}


