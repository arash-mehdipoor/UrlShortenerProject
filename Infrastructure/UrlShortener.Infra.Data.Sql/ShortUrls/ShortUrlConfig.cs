using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Core.Domain.ShortUrls;

namespace UrlShortener.Infra.Data.Sql.ShortUrls
{
    public class ShortUrlConfig : IEntityTypeConfiguration<ShortUrl>
    {
        public void Configure(EntityTypeBuilder<ShortUrl> builder)
        {
            builder.Property(c => c.OriginalUrl).HasMaxLength(200);
            builder.Property(c => c.ShorturlCode).HasMaxLength(300);
        }
    }
}
