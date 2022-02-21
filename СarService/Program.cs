using System;
using System.Collections.Generic;

namespace СarService
{
    class MainClass
    {
        public static void Main(string[] args)
        {

        }
    }

    class CarService
    {
        private int _money;
        private int _pricePerHour;
        private Warehouse warehouse;
        private Dictionary<Warehouse.Details, int> _priceList;
        
    }

    class Warehouse
    {
        private List<Details> _details = new List<Details>();

        public enum Details
        {
            Engine,
            Transmission,
            FuelPump,
            BrakeSystem,
            Wheel,
            Windshield
        }

        public void FillWithGoods()
        {

        }
    }

    class CarDetail
    {
        public string Name { get; private set; }

        public int Price { get; private set; }

        public CarDetail(string name, int price)
        {
            Name = name;
            Price = price;
        }

    }

    class Engine : CarDetail
    {
        public Engine():base("Двигатель", 300) { }
    }

    class Transmission : CarDetail
    {
        public Transmission() : base("Коробка передач", 50) { }
    }

    class FuelPump : CarDetail
    {
        public FuelPump() : base("Топливный насос", 15) { }
    }

    class BrakeSystem : CarDetail
    {
        public BrakeSystem() : base("Тормозная система", 5) { }
    }

    class Wheel : CarDetail
    {
        public Wheel() : base("Колесо", 130) { }
    }
        
    class Windshield : CarDetail
    {
        public Windshield() : base("Лобовое стекло", 150) { }
    }
}
