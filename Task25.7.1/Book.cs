using System.Collections.Generic;

namespace Task25._7._1
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfIssue { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        // Навигационное свойство
        public List<User> Users { get; set; } = new List<User>();
    }
}
