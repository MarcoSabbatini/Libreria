using Libreria.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Libreria.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x => x.Categories)
                .WithMany(c => c.Books)
                .UsingEntity("BookCategory"
                , l => l.HasOne(typeof(Category)).WithMany().HasForeignKey("idCategory").HasPrincipalKey(nameof(Category.Id))
                , r => r.HasOne(typeof(Book)).WithMany().HasForeignKey("idBook").HasPrincipalKey(nameof(Book.Id)).OnDelete(DeleteBehavior.Cascade)
                , j => j.HasKey("idCategory", "idBook"));
        }
    }
}
