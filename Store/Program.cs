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
            bool isEnterShop = false;
            List<Product> products = new List<Product>();

            products.Add(new Product("Молоко", 80));
            products.Add(new Product("Хлеб", 60));
            products.Add(new Product("Макароны", 50));
            products.Add(new Product("Мясо", 150));
            products.Add(new Product("Помидоры", 70));
            products.Add(new Product("Апельсины", 120));

            while (isEnterShop == false)
            {
                Console.Clear();
                Console.WriteLine("Введите enter, если денег нет, но хотите просто посмотреть.\n");
                Console.Write("Сколько у вас денег с собой?: ");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out customerMoney))
                {
                    if (customerMoney > 0)
                    {
                        isEnterShop = true;
                    }                 
                    else
                    {
                        Console.WriteLine("Вы за кого меня принимаете?");
                        Console.ReadKey();
                    }
                }
                else if (userInput == "enter")
                {
                    isEnterShop = true;
                }
                else
                {
                    Console.Write("Не могли бы повторить? Я не расслышал.");
                    Console.ReadKey();
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
                        ArrangeTrade();
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

        private void ArrangeTrade()
        {
            Product productForSell;
            string productName;

            Console.Write("Что хотите купить?: ");
            productName = Console.ReadLine();
            productForSell = _salesman.FindProduct(productName);

            if (productForSell != null)
            {
                if (_customer.Money >= productForSell.Price)
                {
                    _customer.BuyProduct(productForSell, productForSell.Price);
                    _salesman.SellProduct(productForSell, productForSell.Price);
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
    public int Price { get; private set; }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }
}

class Person
{
    protected List<Product> Products = new List<Product>();

    public int Money { get; protected set; }

    public Person(int money, List<Product> products)
    {
        Money = money;
        Products = products;
    }

    public virtual void ShowAllProducts()
    {
        foreach (var product in Products)
        {
            Console.WriteLine($"{product.Name}. Цена за упаковку: {product.Price} рублей");
        }
        Console.ReadKey();
    }
}

class Salesman : Person
{
    public Salesman(int money, List<Product> products) : base(0, products) { }

    public Product FindProduct(string productName)
    {
        for (int i = 0; i < Products.Count; i++)
        {
            if (Products[i].Name.ToLower() == productName.ToLower())
            {
                return Products[i];
            }
        }

        return null;
    }

    public void SellProduct(Product product, int transactionAmount)
    {
        Money += transactionAmount;
        Products.Add(product);
    }
}


class Customer : Person
{
    public Customer(int money, List<Product> products) : base(money, products) { }

    public void BuyProduct(Product product, int transactionAmount)
    {
        Money -= transactionAmount;
        Products.Add(product);
    }

    public override void ShowAllProducts()
    {
        Console.WriteLine("У вас в пакете:");

        foreach (var product in Products)
        {
            Console.Write($"{product.Name} ");
        }

        Console.ReadKey();
    }
}
