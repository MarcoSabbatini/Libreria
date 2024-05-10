using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Libreria.Models.Entities;

namespace Libreria.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(x => x.Name);
            builder.HasOne(e => e.Categories)
                .WithMany(e => e.)
                .HasForeignKey(e => e.Id);
        }
    }
}
