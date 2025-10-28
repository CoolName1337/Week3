using DataAccessEFLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessEFLayer.Configurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(b=>b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasDefaultValue("Без названия");

            builder.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                    new Book() { Id = 1, Title = "shi1", AuthorId = 1 },
                    new Book() { Id = 2, Title = "shi2", AuthorId = 2 },
                    new Book() { Id = 3, Title = "shi3", AuthorId = 3 },
                    new Book() { Id = 4, Title = "shi4", AuthorId = 2 }
                );
        }

    }
}
