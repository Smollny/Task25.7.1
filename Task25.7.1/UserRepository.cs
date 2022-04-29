using System.Collections.Generic;
using System.Linq;

namespace Task25._7._1
{
    class UserRepository
    {
        // получение всех пользователей
        public static List<User> GetAll()
        {
            using AppContext db = new();
            return db.users.ToList();
        }

        //получение записи по ID
        public static User GetById(int id)
        {
            using AppContext db = new();
            User user = db.users.FirstOrDefault(user => user.Id == id);
            if (user != null)
                return user;
            return null;
        }

        // добавление пользователя
        public static void Add(User user)
        {
            using AppContext db = new();
            db.users.Add(user);
            db.SaveChanges();
        }

        //удаление записи по ID
        public static void DeleteById(int id)
        {
            using AppContext db = new();
            User user = db.users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                db.users.Remove(user);
                db.SaveChanges();
            }
        }

        //обновление имени по ID
        public static void UpdateNameById(int id, string name)
        {
            using AppContext db = new();
            User user = db.users.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                user.Name = name;
                db.users.Update(user);
                db.SaveChanges();
            }
        }
    }
}
