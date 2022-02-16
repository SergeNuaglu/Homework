using System;
using System.Collections.Generic;

namespace Supermarket
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int clientCount = 10;
            Dictionary<string, int> productRange = new Dictionary<string, int>();

            productRange.Add("Хлеб", 43);
            productRange.Add("Лосось", 300);
            productRange.Add("Сыр", 270);
            productRange.Add("Виноград", 140);
            productRange.Add("Пельмени", 132);
            productRange.Add("Сок", 74);
            productRange.Add("Капуста", 30);
            productRange.Add("Вино", 466);
            productRange.Add("Креветки", 340);
            productRange.Add("Кетчуп", 69);

            for (int i = 0; i < clientCount; i++)
            {
                
            }
        }
    }

    class Supermarket
    {
        private Queue<Client> _clients = new Queue<Client>();

        public void GetTotalAmountPaid()
        {
            foreach (var client in _clients)
            {
                List<Product> foodBasket = new List<Product>();

            }
        }
    }

    class Client
    {
        private List<Product> _foodBasket = new List<Product>();
        private int _money;

        public Client(List<Product> foodBasket)
        {
            _foodBasket = foodBasket;
        }

        public int GetTotalAmountPaid()
        {
            int totalAmountPaid = 0;

            foreach (var product in _foodBasket)
            {
                totalAmountPaid += product.Price;
            }

            return totalAmountPaid;
        }
    }

    class Product
    {
        public string Name { get; private set; }

        public int Price { get; private set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
