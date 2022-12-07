using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Database
{
    public class PersonDbContext: DbContext
    {
        public DbSet<Person> Persons => Set<Person>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./PersonDatabase.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasData(
                new Person { Id= 1, Name = "Alice", City = "New York" },
                new Person { Id = 2, Name = "John", City = "London" }
            );
        }
    }
}
