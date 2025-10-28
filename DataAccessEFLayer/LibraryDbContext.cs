using DataAccessEFLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessEFLayer
{
    public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);

            base.OnModelCreating(modelBuilder);


        }
    }
}
