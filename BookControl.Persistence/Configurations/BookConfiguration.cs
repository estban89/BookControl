using BookControl.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookControl.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(x => x.Author)
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(x => x.Isbn)
                .IsRequired()
                .HasMaxLength(15);

            builder.ToTable(nameof(Book), schema: "BookControl");
        }
    }
}
