using System;
using System.Collections.Generic;

namespace Store
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int money = 0;
            string userInput;
            bool hasMoney = false;
            List<Product> products = new List<Product>();

            products.Add(new Product("Молоко", 80));
            products.Add(new Product("Хлеб", 60));
            products.Add(new Product("Макароны", 50));
            products.Add(new Product("Мясо", 150));
            products.Add(new Product("Помидоры", 70));
            products.Add(new Product("Апельсины", 120));
            Console.Write("Сколько у вас денег с собой?: ");
            userInput = Console.ReadLine();

            while (hasMoney == false)
            {
                if (int.TryParse(userInput, out money))
                {
                    hasMoney = true;
                }
                else
                {
                    Console.Write("Повторите, я не расслышал: ");
                }
            }

            Customer customer = new Customer(money);
            Salesman saleman = new Salesman(products, customer);
            saleman.Work();
        }
    }

    class Salesman
    {
        private Customer _customer;
        private List<Product> _products = new List<Product>();
        private int _money = 0;

        public Salesman(List<Product> products, Customer customer)
        {
            _products = products;
            _customer = customer;
        }

        public void ShowAllProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine($"{product.Name}. Цена за упаковку: {product.PriceForOne} рублей");
            }
            Console.ReadKey();
        }

        public void SellProduct()
        {
            Product productForSell;
            string productName;
            int productCount;
            bool isFound = false; ;

            Console.Write("Что хотите купить?: ");
            productName = Console.ReadLine();

            if (isFound == false)
            {
                for (int i = 0; i < _products.Count && isFound == false; i++)
                {
                    if (_products[i].Name.ToLower() == productName.ToLower())
                    {
                        productForSell = _products[i];
                        Console.Write("Сколько?: ");

                        if (int.TryParse(Console.ReadLine(), out productCount))
                        {
                            if (_customer.Money >= _products[i].PriceForOne * productCount)
                            {
                                _customer.BuyProduct(productForSell, _products[i].PriceForOne, productCount);
                                _money += _products[i].PriceForOne * productCount;
                                isFound = true;
                                Console.WriteLine($"Вы приобрели {productName}");
                            }
                            else
                            {
                                Console.WriteLine("Вам столько не по карману");
                                isFound = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Я с такими цифрами не знаком");
                            isFound = true;
                        }
                    }
                }
            }

            if (isFound == false)
            {
                Console.WriteLine("Такого товара нет!");
            }

            Console.ReadKey();
        }

        public void Work()
        {
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"В вашем кошельке {_customer.Money} рублей");
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("\nСписок действий:\n\nПоказать весь ассортимент товаров - 1\nКупить товар - 2\nВывести купленные товары - 3\nПокинуть магазин - 4\n");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Добро пожаловать!\n");
                Console.Write("Слушаю вас: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowAllProducts();
                        break;
                    case "2":
                        SellProduct();
                        break;
                    case "3":
                        _customer.ShowAllPurchased();
                        break;
                    case "4":
                        isWork = false;
                        break;
                }
            }
        }
    }

    class Product
    {

        public string Name { get; private set; }
        public int PriceForOne { get; private set; }

        public Product(string name, int price)
        {
            Name = name;
            PriceForOne = price;
        }
    }

    class Customer
    {
        private List<Product> _purchasedItems = new List<Product>();
        public int Money { get; private set; }

        public Customer(int money)
        {
            Money = money;
        }

        public void BuyProduct(Product productForBuy, int price, int count)
        {
            Money -= price * count;
            _purchasedItems.Add(productForBuy);
        }

        public void ShowAllPurchased()
        {
            foreach (var items in _purchasedItems)
            {
                Console.Write(items.Name + " ");
            }

            Console.ReadKey();
        }

    }
}
