using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace UrlShortener.EndPoint.Web.Controllers
{
    public class UrlController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string originalUrl)
        {
            var client = new RestClient("https://localhost:5001/");

            var getShortUrlsRequest = new RestRequest("api/v1/ShortUrls", Method.POST);
            getShortUrlsRequest.AddParameter("originalUrl", originalUrl);
            var getResult = client.Post(getShortUrlsRequest);

            if (getResult.IsSuccessful)
            {
                return RedirectToAction(actionName: nameof(ShowWebSite), routeValues: new { originalUrl = getResult.Content });
            }
            return View();
        }

        public IActionResult ShowWebSite(string originalUrl)
        {
            var client = new RestClient("https://localhost:5001/");
            var getShortUrlsRequest = new RestRequest("api/v1/ShortUrls", Method.GET);
            getShortUrlsRequest.AddParameter("redirectUrlCode", originalUrl.Replace("\"",""));
            var getResult = client.Get(getShortUrlsRequest);
            return Redirect(getResult.Content.Replace("\"", ""));
        }


    }
}
