using System.Collections.Generic;

namespace Task25._7._1
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
        // Навигационное свойство
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
