using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nkey.BookRegistration.Challenge.Data.Entities;

namespace Nkey.BookRegistration.Challenge.Data.Context.EntitiesMaping
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book));
            builder.HasKey(x => x.Id)
                .HasName("book_id");
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(x => x.Code)
                .HasColumnName("code")
                .IsRequired();
            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();
            builder.Property(x => x.Author)
                .HasColumnName("author")
                .IsRequired();
            builder.Property(x => x.Isbn)
                .HasColumnName("isbn")
                .IsRequired();
            builder.Property(x => x.ReleaseYear)
                .HasColumnName("release_year")
                .IsRequired();
        }
    }
}
