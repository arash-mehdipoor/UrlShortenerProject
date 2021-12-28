using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Domain.ShortUrls;

namespace UrlShortener.Core.ApplicationServices.ShortUrls
{
    public interface IShortUrlService
    {
        string Add(ShortUrl shortUrl);
        string GetRedirectUrlByPath(string shorturlCode);
        void WasObserved(string shorturlCode);
    }
}
