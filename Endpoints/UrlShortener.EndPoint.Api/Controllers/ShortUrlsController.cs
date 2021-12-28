using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UrlShortener.Core.ApplicationServices.ShortUrls;
using UrlShortener.Core.Domain.ShortUrls;
using UrlShortener.EndPoint.Api.Helpers;

namespace UrlShortener.EndPoint.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class ShortUrlsController : ControllerBase
    {
        private readonly IShortUrlService _shortUrlService;

        public ShortUrlsController(IShortUrlService shortUrlService)
        {
            _shortUrlService = shortUrlService;
        }
        [HttpPost]
        public IActionResult Create([FromForm] string originalUrl)
        {
            if (!string.IsNullOrEmpty(originalUrl))
            {
                var shortUrl = new ShortUrl
                {
                    OriginalUrl = originalUrl
                };
                string redirectUrl = _shortUrlService.Add(shortUrl);
                return Ok(redirectUrl);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult RedirectTo(string redirectUrlCode)
        {
            if (string.IsNullOrEmpty(redirectUrlCode))
                return NotFound();
            var shortUrl = _shortUrlService.GetRedirectUrlByPath(redirectUrlCode);
            if (shortUrl == null)
            {
                return NotFound();
            }
            else
            {
                _shortUrlService.WasObserved(redirectUrlCode);
                return Ok(shortUrl);
            }
        }

    }
}
