using Microsoft.EntityFrameworkCore;
namespace Model

{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
 

        public DbSet<Osoba> Kandidati { get; set; }
        public DbSet<Izbor> Izbor { get; set; }
        public DbSet<Admin> Admin { get; set; }



    }
}
