using System;
using System.Collections.Generic;

namespace Store
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int customerMoney = 0;
            int salesmanMoney = 0;
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
                if (int.TryParse(userInput, out customerMoney))
                {
                    hasMoney = true;
                }
                else
                {
                    Console.Write("Повторите, я не расслышал: ");
                }
            }

            Store store = new Store(new Customer(customerMoney, new List<Product>()), new Salesman(salesmanMoney, products));
            store.Work();
        }
    }

    class Store
    {
        private Customer _customer;
        private Salesman _salesman;

        public Store(Customer customer, Salesman salesman)
        {
            _customer = customer;
            _salesman = salesman;
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
                        _salesman.ShowAllProducts();
                        break;
                    case "2":
                        SellProduct();
                        break;
                    case "3":
                        _customer.ShowAllProducts();
                        break;
                    case "4":
                        isWork = false;
                        break;
                }
            }
        }

        private void SellProduct()
        {
            Product productForSell;
            string productName;

            Console.Write("Что хотите купить?: ");
            productName = Console.ReadLine();
            productForSell = _salesman.FindProduct(productName);

                if (productForSell != null)
                {
                    if (_customer.Money >= productForSell.PriceForOne)
                    {
                        _customer.MakeDeal(productForSell, productForSell.PriceForOne);
                        _salesman.MakeDeal(productForSell, productForSell.PriceForOne);
                        Console.WriteLine($"Вы приобрели {productName}");
                    }
                    else
                    {
                        Console.WriteLine("Это вам не по карману");
                    }
                }
                else
                {
                    Console.WriteLine("Такого товара нет!");
                }

            Console.ReadKey();
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

abstract class Person
{
    protected List<Product> _products = new List<Product>();

    public int Money { get; protected set; }

    public Person(int money, List<Product> products)
    {
        Money = money;
        _products = products;
    }

    public virtual void ShowAllProducts()
    {
        foreach (var product in _products)
        {
            Console.WriteLine($"{product.Name}. Цена за упаковку: {product.PriceForOne} рублей");
        }
        Console.ReadKey();
    }

    public abstract void MakeDeal(Product product, int transactionAmount);
}

class Salesman : Person
{
    public Salesman(int money, List<Product> products) : base(0, products) { }

    public Product FindProduct(string productName)
    {
        for (int i = 0; i < _products.Count; i++)
        {
            if (_products[i].Name.ToLower() == productName.ToLower())
            {
                return _products[i];
            }
        }

        return null;
    }

    public override void MakeDeal(Product product, int transactionAmount)
    {
        Money += transactionAmount;
        _products.Add(product);
    }
}


class Customer : Person
{
    public Customer(int money, List<Product> products) : base(money, products) { }

    public override void MakeDeal(Product product, int transactionAmount)
    {
        Money -= transactionAmount;
        _products.Add(product);
    }

    public override void ShowAllProducts()
    {
        Console.WriteLine("У вас в пакете:");

        foreach (var product in _products)
        {
            Console.Write($"{product.Name} ");
        }

        Console.ReadKey();
    }
}
