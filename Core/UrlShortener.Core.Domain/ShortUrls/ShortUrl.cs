using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Domain.Common;

namespace UrlShortener.Core.Domain.ShortUrls
{
    public class ShortUrl : BaseEntity
    {
        public string OriginalUrl { get; set; }
        public string ShorturlCode { get; set; }
        public int Observed { get; set; }
    }
}
