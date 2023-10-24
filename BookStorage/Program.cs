using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStorage
{
    internal static class Program
    {
        private const char MenuAddBook = '1';
        private const char MenuRemoveBook = '2';
        private const char MenuShowAllBooks = '3';
        private const char MenuShowBooksByTitle = '4';
        private const char MenuShowBooksByAuthor = '5';
        private const char MenuShowBooksByYear = '6';
        private const char MenuExit = '7';

        private static void Main()
        {
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
                        storage.ShowBookByTitle();
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

        public int GetNewInventoryNumber()
        {
            Book selectedBook = _books.OrderBy(book => book.InventoryNumber).FirstOrDefault();
            return selectedBook == null ? MinBookCount : selectedBook.InventoryNumber + MinBookCount;
        }

        public void AddBook()
        {
            const int yearRangeFrom = 1700;
            const int yearRangeTo = 2022;

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

            do
            {
                Console.Write("Введите год: ");
                int.TryParse(Console.ReadLine(), out bookYear);
            }
            while (bookYear < yearRangeFrom || bookYear > yearRangeTo);

            int newInventoryNumber = GetNewInventoryNumber();
            var book = new Book(newInventoryNumber, bookTitle, bookAuthor, bookYear);
            _books.Add(book);
            Console.WriteLine("Книга успешно добавлена");
        }

        public void RemoveBook()
        {
            int bookInventoryNumber;

            do
            {
                Console.Write("Введите инвентарный номер книги: ");
                int.TryParse(Console.ReadLine(), out bookInventoryNumber);
            }
            while (bookInventoryNumber < MinBookCount);

            Book selectedBook = _books.FirstOrDefault(book => book.InventoryNumber == bookInventoryNumber);

            if (selectedBook == null)
            {
                Console.WriteLine("Книга с указанным инвентарным номером не найдена");
            }
            else
            {
                _books.Remove(selectedBook);
                Console.WriteLine("Книга успешно удалена");
            }
        }

        public void ShowAllBooks()
        {
            if (_books.Count < MinBookCount)
            {
                Console.WriteLine("В хранилище нет необходимых книг");
            }

            foreach (Book book in _books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public void ShowBookByTitle()
        {
            Console.Write("Введите название книги для поиска: ");
            string searchTitle = Console.ReadLine();
            var searchResult = _books.FindAll(book => book.Title == searchTitle);

            if (searchResult.Count >= MinBookCount)
            {
                Console.WriteLine($"Книги с названием '{searchTitle}':");

                foreach (var book in searchResult)
                {
                    Console.WriteLine($"Автор: {book.Author}, Год: {book.Year}");
                }
            }
            else
            {
                Console.WriteLine($"Книги с названием '{searchTitle}' не найдены.");
            }
        }

        public void ShowBooksByAuthor()
        {
            Console.Write("Введите имя автора: ");
            string authorName = Console.ReadLine();
            var authorBooks = _books.FindAll(book => book.Author == authorName);

            if (authorBooks.Count >= MinBookCount)
            {
                Console.WriteLine($"Книги автора {authorName}:");

                foreach (var book in authorBooks)
                {
                    Console.WriteLine($"Название: {book.Title}, Год: {book.Year}");
                }
            }
            else
            {
                Console.WriteLine($"Книги автора {authorName} не найдены.");
            }
        }

        public void ShowBooksByYear()
        {
            Console.Write("Введите год: ");
            int searchYear = int.Parse(Console.ReadLine());
            var yearBooks = _books.FindAll(book => book.Year == searchYear);

            if (yearBooks.Count >= MinBookCount)
            {
                Console.WriteLine($"Книги, опубликованные в {searchYear} году:");

                foreach (var book in yearBooks)
                {
                    Console.WriteLine($"Название: {book.Title}, Автор: {book.Author}");
                }
            }
            else
            {
                Console.WriteLine($"Книг, опубликованных в {searchYear} году не найдено.");
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
