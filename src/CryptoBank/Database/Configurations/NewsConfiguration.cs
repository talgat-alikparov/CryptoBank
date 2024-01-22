using CryptoBank.Features.News.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoBank.Database.Configurations;

public class NewsConfiguration : IEntityTypeConfiguration<News>
{
    public void Configure(EntityTypeBuilder<News> builder)
    {
        builder.ToTable("news", "public");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").IsRequired();
        builder.Property(x => x.Title).HasColumnName("title").IsRequired().HasMaxLength(255);
        builder.Property(x => x.Date).HasColumnName("date").IsRequired();
        builder.Property(x => x.Author).HasColumnName("author").IsRequired().HasMaxLength(255);
        builder.Property(x => x.Content).HasColumnName("content").IsRequired();
    }
}