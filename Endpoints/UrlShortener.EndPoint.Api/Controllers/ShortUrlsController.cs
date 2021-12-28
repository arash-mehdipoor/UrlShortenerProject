using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Core.ApplicationServices.ShortUrls;
using UrlShortener.Core.Domain.ShortUrls;

namespace UrlShortener.EndPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUrlsController : ControllerBase
    {
        private readonly IShortUrlService _shortUrlService;

        public ShortUrlsController(IShortUrlService shortUrlService)
        {
            _shortUrlService = shortUrlService;
        }
        [HttpPost]
        public IActionResult Create(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                var shortUrl = new ShortUrl
                {
                    OriginalUrl = url
                };
                int shortUrlId = _shortUrlService.Add(shortUrl);
                return Ok(shortUrlId);
            }
            return Ok();
        }


    }
}
