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

    }

    class Warehouse
    {
        private List<SpareParts> _spareParts = new List<SpareParts>();

        enum SpareParts
        {
            Engine,
            Transmission,
            FuelPump,
            BrakeSystem,
            Wheel,
            Windshield
        }
    }

    class SpareParts
    {

    }

    class Engine : SpareParts
    {

    }

    class Transmission : SpareParts
    {

    }

    class FuelPump: SpareParts
    {

    }

    class BrakeSystem: SpareParts
    {

    }

    class Wheel : SpareParts
    {

    }

    class Windshield : SpareParts
    {

    }
}
