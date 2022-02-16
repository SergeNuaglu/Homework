using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int clientCount = 10;
            Supermarket supermarket = new Supermarket();
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
                new Client(new List<Product>()).FillBasket(productRange);
            }
        }
    }

    class Supermarket
    {
        private Queue<Client> _clients = new Queue<Client>();

        public void PutInQueue(Client client)
        {
            _clients.Enqueue(client);
        }

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
        private List<Product> _foodBasket;
        private int _money;

        public Client(List<Product> foodBasket)
        {           
            _foodBasket = foodBasket;
        }

        public void FillBasket(Dictionary<string, int> productRange )
        {
            Random random = new Random();
            int productCount;

            productCount = random.Next(0, productRange.Count);

            for (int i = 0; i < productCount; i++)
            {
                int productIndex = random.Next(0, productRange.Count);
                string productName = productRange.ElementAt(productIndex).Key;
                _foodBasket.Add(new Product(productName, productRange[productName]));
            }
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

        public void BuyProduct(int totalAmountPaid)
        {
            bool isCanBuy = false;

            while (isCanBuy == false)
            {
                if (_money >= totalAmountPaid)
                {
                    _money -= totalAmountPaid;
                    isCanBuy = true;
                }
                else
                {
                    Console.WriteLine("У клиента недостаточно денег");
                    DiscardProduct();
                }
            }
        }

        private void DiscardProduct()
        {
            Random random = new Random();
            int productIndex;

            productIndex = random.Next(random.Next(0, _foodBasket.Count));
            Console.WriteLine($"Клиент из корзины выложил {_foodBasket[productIndex]}");
            _foodBasket.RemoveAt(productIndex);
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
