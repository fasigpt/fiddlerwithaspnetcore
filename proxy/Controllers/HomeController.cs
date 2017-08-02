using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics.Tracing;
using Microsoft.Extensions.Logging;
using System.Net;
using proxy;

namespace proxy.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> proxy()
        {
            _logger.LogWarning("calling outoging call");
            var task = downloadFile();
            string data = await task;
            ViewData["Message"] = data;
            return View();
        }

        public async Task<String> downloadFile()
        {

            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new MyHttpProxy(),
                UseProxy = true,
                UseDefaultCredentials = true,                

            };                      

             var client = new HttpClient(httpClientHandler);            
             String httpResponse = await client.GetStringAsync("http://yourproxyserviceURI");
             return httpResponse;
                       
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
