using System;

namespace SwappingValues
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string name = "Ivanov";
            string surname = "Igor";

            Console.WriteLine("Name: " + name + "\nSurname: " + surname);
            Swap(ref name, ref surname);
            Console.WriteLine("Name: " + name + "\nSurname: " + surname);
        }

        private static void Swap(ref string firstValue, ref string secondValue)
        {
            string swappingData;

            swappingData = firstValue;
            firstValue = secondValue;
            secondValue = swappingData;
        }
    }
}
