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
                string redirectUrl = _shortUrlService.Add(shortUrl);
                return Ok(redirectUrl);
            }
            return BadRequest();
        }

        [HttpGet("/ShortUrls/RedirectTo/{path:required}", Name = "RedirectTo")]
        public IActionResult RedirectTo(string path)
        {

            if (string.IsNullOrEmpty(path))
                return NotFound();
            var shortUrl = _shortUrlService.GetRedirectUrlByPath(path);
            if (shortUrl == null)
                return NotFound();
            return Redirect(shortUrl);
        }

    }
}
