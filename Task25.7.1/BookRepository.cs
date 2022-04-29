using System.Collections.Generic;
using System.Linq;

namespace Task25._7._1
{
    public class BookRepository
    {
        // получение всех книг
        public static List<Book> GetAll()
        {
            using AppContext db = new();
            return db.books.ToList();
        }

        //получение записи по ID
        public static Book GetById(int id)
        {
            using AppContext db = new();
            Book book = db.books.FirstOrDefault(book => book.Id == id);
            if (book != null)
                return book;
            return null;
        }

        // добавление книги
        public static void Add(Book book)
        {
            using AppContext db = new();
            db.books.Add(book);
            db.SaveChanges();
        }

        //удаление записи по ID
        public static void DeleteById(int id)
        {
            using AppContext db = new();
            Book book = db.books.FirstOrDefault(book => book.Id == id);
            if (book != null)
            {
                db.books.Remove(book);
                db.SaveChanges();
            }
        }

        //обновление года по ID
        public static void UpdateYearOfIssueById(int id, int year)
        {
            using AppContext db = new();
            Book book = db.books.FirstOrDefault(book => book.Id == id);
            if (book != null)
            {
                book.YearOfIssue = year;
                db.books.Update(book);
                db.SaveChanges();
            }
        }
    }
}
