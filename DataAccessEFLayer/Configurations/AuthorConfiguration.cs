using DataAccessEFLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessEFLayer.Configurations
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasDefaultValue("Без имени");

            builder.Property(a => a.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

            builder.HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(
                    new Author() { Id = 1, Name = "chel chelikov", DateOfBirth = new DateOnly(2001,11,20) },
                    new Author() { Id = 2, Name = "chuvak chuvakov", DateOfBirth = new DateOnly(2002, 10, 21) },
                    new Author() { Id = 3, Name = "patsan patsanov", DateOfBirth = new DateOnly(2003, 9, 22) },
                    new Author() { Id = 4, Name = "marat kaskinov", DateOfBirth = new DateOnly(2004, 8, 23) }
                );
        }
    }
}
