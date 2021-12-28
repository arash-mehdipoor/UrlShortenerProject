using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Core.Domain.ShortUrls
{
    public class ShortUrl
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string RedirectUrl { get; set; }
        public int Observed { get; set; }
    }
}
