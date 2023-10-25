using System;
using System.Collections.Generic;

namespace BookStorage
{
    internal static class Program
    {
        private static void Main()
        {
            const char MenuAddBook = '1';
            const char MenuRemoveBook = '2';
            const char MenuShowAllBooks = '3';
            const char MenuShowBooksByTitle = '4';
            const char MenuShowBooksByAuthor = '5';
            const char MenuShowBooksByYear = '6';
            const char MenuExit = '7';

            Console.WriteLine("============== МЕНЮ =============");
            Console.WriteLine($"{MenuAddBook}. Добавить книгу");
            Console.WriteLine($"{MenuRemoveBook}. Удалить книгу");
            Console.WriteLine($"{MenuShowAllBooks}. Показать все книги");
            Console.WriteLine($"{MenuShowBooksByTitle}. Показать книги по названию");
            Console.WriteLine($"{MenuShowBooksByAuthor}. Показать книги по автору");
            Console.WriteLine($"{MenuShowBooksByYear}. Показать книги по году");
            Console.WriteLine($"{MenuExit}. Выход");
            Console.WriteLine("================================");

            var storage = new Storage();
            var selectedMenu = '\0';

            while (selectedMenu != MenuExit)
            {
                Console.Write("\nВыберите пункт меню: ");
                selectedMenu = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (selectedMenu)
                {
                    case MenuAddBook:
                        storage.AddBook();
                        break;

                    case MenuRemoveBook:
                        storage.RemoveBook();
                        break;

                    case MenuShowAllBooks:
                        storage.ShowAllBooks();
                        break;

                    case MenuShowBooksByTitle:
                        storage.ShowBooksByTitle();
                        break;

                    case MenuShowBooksByAuthor:
                        storage.ShowBooksByAuthor();
                        break;

                    case MenuShowBooksByYear:
                        storage.ShowBooksByYear();
                        break;

                    default:
                        Console.WriteLine("Такого пункта меню не существует");
                        break;
                }
            }
        }
    }

    internal sealed class Storage
    {
        private const int MinBookCount = 1;
        private readonly List<Book> _books = new List<Book>();

        public void AddBook()
        {
            const int yearRangeFrom = 1700;
            const int yearRangeTo = 2023;

            string bookTitle = ReadNonEmptyString("Введите название книги: ");
            string bookAuthor = ReadNonEmptyString("Введите автора: ");
            int bookYear = GetValidIntegerInput("Введите год: ", yearRangeFrom, yearRangeTo);
            var book = new Book(bookTitle, bookAuthor, bookYear);
            _books.Add(book);
            Console.WriteLine("Книга успешно добавлена");
        }

        public void RemoveBook()
        {
            int bookInventoryNumber = GetValidIntegerInput("Введите инвентарный номер книги: ", MinBookCount, int.MaxValue);

            foreach (Book book in _books)
            {
                if (book.InventoryNumber == bookInventoryNumber)
                {
                    _books.Remove(book);
                    Console.WriteLine("Книга успешно удалена");
                    return;
                }
            }

            Console.WriteLine("Книга с указанным инвентарным номером не найдена");
        }

        public void ShowAllBooks()
        {
            if (_books.Count < MinBookCount)
            {
                Console.WriteLine("В хранилище нет необходимых книг");
                return;
            }

            foreach (Book book in _books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public void ShowBooksByTitle()
        {
            Console.Write("Введите название книги для поиска: ");
            string searchTitle = Console.ReadLine();
            ShowBooks(
                book => book.Title == searchTitle,
                $"Книги с названием '{searchTitle}' не найдены.",
                book => $"Автор: {book.Author}, Год: {book.Year}");
        }

        public void ShowBooksByAuthor()
        {
            Console.Write("Введите имя автора: ");
            string authorName = Console.ReadLine();
            ShowBooks(
                book => book.Author == authorName,
                $"Книги автора {authorName} не найдены.",
                book => $"Название: {book.Title}, Год: {book.Year}");
        }

        public void ShowBooksByYear()
        {
            Console.Write("Введите год: ");
            int searchYear = int.Parse(Console.ReadLine());
            ShowBooks(
                book => book.Year == searchYear,
                $"Книг, опубликованных в {searchYear} году не найдено.",
                book => $"Название: {book.Title}, Автор: {book.Author}");
        }

        private void ShowBooks(Func<Book, bool> filter, string notFoundMessage, Func<Book, string> format)
        {
            var searchResult = new List<Book>();

            foreach (var book in _books)
            {
                if (filter(book))
                {
                    searchResult.Add(book);
                }
            }

            if (searchResult.Count >= MinBookCount)
            {
                Console.WriteLine("Результаты поиска:");

                foreach (var book in searchResult)
                {
                    Console.WriteLine(format(book));
                }
            }
            else
            {
                Console.WriteLine(notFoundMessage);
            }
        }

        private string ReadNonEmptyString(string prompt)
        {
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(input));

            return input;
        }

        public int GetValidIntegerInput(string prompt, int minValue, int maxValue)
        {
            int userInput;
            bool isValidInput;

            do
            {
                Console.Write(prompt);
                isValidInput = int.TryParse(Console.ReadLine(), out userInput);
            }
            while (isValidInput == false || userInput < minValue || userInput > maxValue);

            return userInput;
        }
    }

    internal sealed class Book
    {
        public static int Counter;

        public Book(string title, string author, int year)
        {
            InventoryNumber = ++Counter;
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
