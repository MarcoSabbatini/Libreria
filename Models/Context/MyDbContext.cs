using Microsoft.EntityFrameworkCore;
using Libreria.Models.Entities;

namespace Libreria.Models.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }

}
