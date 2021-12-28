using UrlShortener.Core.ApplicationServices.ShortUrls;
using UrlShortener.Core.Domain.ShortUrls;
using UrlShortener.Infra.Data.Sql.Context;

namespace UrlShortener.Infra.Data.Sql.ShortUrls
{
    public class ShortUrlRepasitory : IShortUrlService
    {
        private readonly DatabaseContext _context;

        public ShortUrlRepasitory(DatabaseContext context)
        {
            _context = context;
        }

        public int Add(ShortUrl shortUrl)
        {
            _context.ShortUrls.Add(shortUrl);
            _context.SaveChanges();
            return shortUrl.Id;
        }
    }
}
