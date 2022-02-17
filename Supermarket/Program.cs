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
                Client client = new Client(new List<Product>());
                client.FillBasket(productRange);
                supermarket.PutInQueue(client);
            }

            Console.WriteLine($"На кассе очередь из {clientCount} клиентов");
            Console.WriteLine("Нажмите Enter, чтобы начать обслуживание");
            Console.ReadKey();
            supermarket.ServeCustomers();
        }
    }

    class Supermarket
    {
        private Queue<Client> _clients = new Queue<Client>();

        public void PutInQueue(Client client)
        {
            _clients.Enqueue(client);
        }

        public void ServeCustomers()
        {
            int clientNumber = 1;
            int clientCount = _clients.Count;
            int clientMoney = 0;
            int totalAmountPaid;
            int change;
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"{clientNumber}-й клиент\n");

                if (clientMoney == 0)
                {
                    clientMoney = _clients.Peek().CountMoney();
                }

                Console.WriteLine($"Денег у клиента - {clientMoney}\n");
                Console.WriteLine($"Продукты в корзине: \n");
                _clients.Peek().ShowAllProducts();
                totalAmountPaid = _clients.Peek().GetTotalAmountPaid();
                Console.WriteLine($"\nКлиент должен заплатить: {totalAmountPaid}");

                if (clientMoney >= totalAmountPaid)
                {
                    Console.WriteLine("У клиента хватает денег и он покупает продукты");
                    change = _clients.Dequeue().BuyProduct(totalAmountPaid);
                    Console.WriteLine($"Сдача - {change} рублей");
                    clientMoney = 0;
                    clientNumber++;
                }
                else
                {
                    Console.WriteLine($"У клиента не хватает денег и он выкладывает {_clients.Peek().DiscardProduct()} из корзины ");
                }

                if (clientNumber > clientCount)
                {
                    isWork = false;
                }

                Console.ReadKey();
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

        public void FillBasket(Dictionary<string, int> productRange)
        {
            Random random = new Random();
            int productCount;
            int minProductCount = 3;

            productCount = random.Next(minProductCount, productRange.Count);

            for (int i = 0; i < productCount; i++)
            {
                int productIndex = random.Next(0, productRange.Count);
                string productName = productRange.ElementAt(productIndex).Key;
                _foodBasket.Add(new Product(productName, productRange[productName]));
            }
        }

        public int CountMoney()
        {
            int minMoneyCount = 500;
            int maxMoneyCount = 1000;
            Random random = new Random();

            _money = random.Next(minMoneyCount, maxMoneyCount);
            return _money;
        }

        public void ShowAllProducts()
        {
            foreach (var product in _foodBasket)
            {
                Console.WriteLine($"{product.Name} - {product.Price} рублей");
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

        public int BuyProduct(int totalAmountPaid)
        {
            _money -= totalAmountPaid;
            return _money;
        }

        public string DiscardProduct()
        {
            Random random = new Random();
            int productIndex;
            string productName;

            productIndex = random.Next(random.Next(0, _foodBasket.Count));
            productName = _foodBasket[productIndex].Name;
            _foodBasket.RemoveAt(productIndex);
            return productName;
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
