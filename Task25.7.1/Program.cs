using System;
using System.Collections.Generic;
using System.Linq;

namespace Task25._7._1
{
    class Program
    {
        static void Main(string[] args)
        {
            using AppContext db = new AppContext();
            Console.WriteLine("Success...");
            //UserRepository.Add(new User { Name = "Иванов", Email = "ivanov@mail.ru" });
            //UserRepository.Add(new User { Name = "Петров", Email = "petrov@mail.ru" });
            //BookRepository.Add(new Book { Title = "Капитанская дочка", YearOfIssue = 1836, Genre = "роман", Author = "А. С. Пушкин" });
            //BookRepository.Add(new Book { Title = "Руслан и Людмила", YearOfIssue = 1820, Genre = "поэма", Author = "А. С. Пушкин" });
            //BookRepository.Add(new Book { Title = "Кавказский пленник", YearOfIssue = 1821, Genre = "поэма", Author = "А. С. Пушкин" });
            //BookRepository.Add(new Book { Title = "Арап Петра Великого", YearOfIssue = 1827, Genre = "проза", Author = "А. С. Пушкин" });
            //BookRepository.Add(new Book { Title = "Сказка о рыбаке и рыбке", YearOfIssue = 1833, Genre = "сказка", Author = "А. С. Пушкин" });
            //BookRepository.Add(new Book { Title = "Герой нашего времени", YearOfIssue = 1840, Genre = "роман", Author = "М. Ю. Лермонтов" });
            //BookRepository.Add(new Book { Title = "Княгиня Лиговская", YearOfIssue = 1882, Genre = "роман", Author = "М. Ю. Лермонтов" });
            //BookRepository.Add(new Book { Title = "Маскарад", YearOfIssue = 1835, Genre = "пьеса", Author = "М. Ю. Лермонтов" });
            //BookRepository.Add(new Book { Title = "Мцыри", YearOfIssue = 1840, Genre = "поэма", Author = "М. Ю. Лермонтов" });
            //BookRepository.Add(new Book { Title = "Парус", YearOfIssue = 1832, Genre = "поэзия", Author = "М. Ю. Лермонтов" });

            foreach (var book in GetListOfBooksOfACertainGenreAndPublishedBetweenCertainYears("поэма", 1810, 1821))
            {
                Console.WriteLine($"{book.Id}: {book.Title}, {book.Author}, {book.Genre}, {book.YearOfIssue}");
            }
            Console.WriteLine(GetCountOfBooksByCertainAuthor("А. С. Пушкин"));
            Console.WriteLine(GetCountOfBooksByCertainGenre("поэма"));
            Console.WriteLine(IsThereBookByCertainAuthorAndTitle("А. С. Пушкин", "поэма"));
            Console.WriteLine(GetLastBookByYear().Title);

            foreach (var book in GetListOfBooksSortedInDescendingOrderOfYear())
            {
                Console.WriteLine($"{book.Id}: {book.Title}, {book.Author}, {book.Genre}, {book.YearOfIssue}");
            }

            foreach (var book in GetListOfBooksSortedAlphabeticallyByTitle())
            {
                Console.WriteLine($"{book.Id}: {book.Title}, {book.Author}, {book.Genre}, {book.YearOfIssue}");
            }

            Console.ReadKey();
        }
        // Получать список книг определенного жанра и вышедших между определенными годами.
        static List<Book> GetListOfBooksOfACertainGenreAndPublishedBetweenCertainYears(string genre, int beginYear, int endYear)
        {
            if (string.IsNullOrEmpty(genre)) return null;
            if (beginYear == 0) return null;
            if (endYear == 0) return null;
            if (beginYear >= endYear) return null;
            using AppContext db = new();
            return db.books.Where(book => book.Genre == genre && book.YearOfIssue > beginYear
            && book.YearOfIssue < endYear).ToList();
        }

        // Получать количество книг определенного автора в библиотеке
        static int GetCountOfBooksByCertainAuthor(string author)
        {
            if (string.IsNullOrEmpty(author)) return -1;
            using AppContext db = new();
            return db.books.Count(book => book.Author == author);
        }

        // Получать количество книг определенного жанра в библиотеке
        static int GetCountOfBooksByCertainGenre(string genre)
        {
            if (string.IsNullOrEmpty(genre)) return -1;
            using AppContext db = new();
            return db.books.Count(book => book.Genre == genre);
        }

        // Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке
        static bool IsThereBookByCertainAuthorAndTitle(string author, string genre)
        {
            if (string.IsNullOrEmpty(genre)) return false;
            if (string.IsNullOrEmpty(author)) return false;
            using AppContext db = new();
            return db.books.Count(book => book.Genre == genre && book.Author == author) > 0;
        }

        // Получать булевый флаг о том, есть ли определенная книга на руках у пользователя
        static bool WhetherUserHasCertainBook(int idBook)
        {
            using AppContext db = new();
            return db.books.FirstOrDefault(b=>b.Id== idBook).Users.Count > 0;
        }

        // Получение последней вышедшей книги
        static Book GetLastBookByYear()
        {
            using AppContext db = new();
            return db.books.OrderByDescending(b => b.YearOfIssue).First();
        }

        // Получение списка всех книг, отсортированного в порядке убывания года их выхода
        static List<Book> GetListOfBooksSortedInDescendingOrderOfYear()
        {
            using AppContext db = new();
            return db.books.OrderByDescending(b => b.YearOfIssue).ToList();
        }

        // Получение списка всех книг, отсортированного в алфавитном порядке по названию
        static List<Book> GetListOfBooksSortedAlphabeticallyByTitle()
        {
            using AppContext db = new();
            return db.books.OrderBy(b => b.Title).ToList();
        }

        // Получать количество книг на руках у пользователя
        static int GetCountOfBooksTheUserHas(int idUser)
        {
            using AppContext db = new();
            return db.users.FirstOrDefault(user => user.Id == idUser).Books.Count;
        }
    }
}
