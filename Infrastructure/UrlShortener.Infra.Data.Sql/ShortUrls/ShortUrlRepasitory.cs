using System;
using System.Linq;
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

        public string Add(ShortUrl shortUrl)
        {
            string shorturlCode = Guid.NewGuid().ToString();
            shortUrl.RedirectUrl = shorturlCode;
            _context.ShortUrls.Add(shortUrl);
            _context.SaveChanges();
            return shortUrl.RedirectUrl;
        }

        public string GetRedirectUrlByPath(string path)
        {
            var shortUrl = _context.ShortUrls.SingleOrDefault(s => s.RedirectUrl == path);
            return shortUrl.OriginalUrl;
        }
    }
}
