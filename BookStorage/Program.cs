using System;
using System.Collections.Generic;

namespace BookStorage
{
    using System.Linq;

    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("============== МЕНЮ ==============");
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Убрать книгу");
            Console.WriteLine("3. Показать все книги");
            Console.WriteLine("4. Показать книги по названию");
            Console.WriteLine("5. Показать книги по автору");
            Console.WriteLine("6. Показать книги по году выпуска");
            Console.WriteLine("7. Выход");
            Console.WriteLine("==================================");

            var storage = new Storage();
            var selectedMenu = '\0';

            while (selectedMenu != '7')
            {
                Console.Write("\nВыберите пункт меню: ");
                selectedMenu = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (selectedMenu)
                {
                    case '1':
                        AddBook(storage);
                        break;
                    case '2':
                        RemoveBook(storage);
                        break;
                    case '3':
                        storage.ShowBooks(Storage.SortingType.All);
                        break;
                    case '4':
                        storage.ShowBooks(Storage.SortingType.Title);
                        break;
                    case '5':
                        storage.ShowBooks(Storage.SortingType.Author);
                        break;
                    case '6':
                        storage.ShowBooks(Storage.SortingType.Year);
                        break;
                    default:
                        Console.WriteLine("Такого пункта меню не существует");
                        break;
                }
            }
        }
        private static void AddBook(Storage storage)
        {
            string bookTitle;

            do
            {
                Console.Write("Введите название книги: ");
                bookTitle = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(bookTitle));

            string bookAuthor;

            do
            {
                Console.Write("Введите автора: ");
                bookAuthor = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(bookAuthor));

            int bookYear;
            int yearRangeFrom = 1700;
            int yearRangeTo = 2022;

            do
            {
                Console.Write("Введите год: ");
                int.TryParse(Console.ReadLine(), out bookYear);
            }
            while (bookYear < yearRangeFrom || bookYear > yearRangeTo);

            int newInventoryNumber = storage.GetNewInventoryNumber();
            var book = new Book(newInventoryNumber, bookTitle, bookAuthor, bookYear);
            storage.AddBook(book);
        }

        private static void RemoveBook(Storage storage)
        {
            int bookInventoryNumber;
            int inventoryNumberRangeFrom = 1;

            do
            {
                Console.Write("Введите инвентаризационный номер: ");
                int.TryParse(Console.ReadLine(), out bookInventoryNumber);
            }
            while (bookInventoryNumber < inventoryNumberRangeFrom);

            storage.RemoveBookAt(bookInventoryNumber);
        }
    }

    internal sealed class Storage
    {
        private readonly List<Book> _books = new List<Book>();

        public enum SortingType
        {
            All,
            Title,
            Author,
            Year
        }

        public int GetNewInventoryNumber()
        {
            Book selectedBook = _books.OrderBy(book => book.InventoryNumber).FirstOrDefault();
            return selectedBook == null ? 1 : selectedBook.InventoryNumber + 1;
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
            Console.WriteLine("Книга успешно добавлена");
        }

        public void RemoveBookAt(int inventoryNumber)
        {
            Book selectedBook = _books.FirstOrDefault(book => book.InventoryNumber == inventoryNumber);

            if (selectedBook == null)
            {
                Console.WriteLine("Книга с указанным инвентаризационным номером - отсутствует");
            }
            else
            {
                _books.Remove(selectedBook);
                Console.WriteLine("Книга успешно удалена");
            }
        }

        public void ShowBooks(SortingType sortingType)
        {
            List<Book> books;

            switch (sortingType)
            {
                case SortingType.All:
                    books = _books;
                    break;
                case SortingType.Title:
                    books = _books.OrderBy(book => book.Title).ToList();
                    break;
                case SortingType.Author:
                    books = _books.OrderBy(book => book.Author).ToList();
                    break;
                case SortingType.Year:
                    books = _books.OrderBy(book => book.Year).ToList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sortingType), sortingType, null);
            }

            if (books.Count < 1)
            {
                Console.WriteLine("В хранилище отсутствуют необходимые книги");
            }

            foreach (Book book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }

    internal sealed class Book
    {
        public Book(int inventoryNumber, string title, string author, int year)
        {
            InventoryNumber = inventoryNumber;
            Title = title;
            Author = author;
            Year = year;
        }

        public int InventoryNumber { get; }
        public string Title { get; }
        public string Author { get; }
        public int Year { get; }

        public override string ToString()
        {
            return $"{InventoryNumber}. {Title} | {Author} | {Year}";
        }
    }
}