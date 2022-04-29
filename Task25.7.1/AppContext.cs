using Microsoft.EntityFrameworkCore;

namespace Task25._7._1
{
    class AppContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Book> books { get; set; }

        public AppContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DELL-G3-15\SQLEXPRESS; Database=EF; Trusted_Connection=True;");
        }
    }
}
