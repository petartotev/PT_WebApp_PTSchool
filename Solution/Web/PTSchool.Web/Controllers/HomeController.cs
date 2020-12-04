using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PTSchool.Web.Models;
using System;
using System.Diagnostics;
using System.Threading;

namespace PTSchool.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache memoryCache;

        //PT: INJECT LOGGER (BY DEFAULT)
        //PT: INJECT CACHE
        public HomeController(
            ILogger<HomeController> logger,
            IMemoryCache memoryCache)
        {
            _logger = logger;
            this.memoryCache = memoryCache;
        }

        public IActionResult RegisterPolicy()
        {
            return this.View();
        }

        public IActionResult CacheTest()
        {
            if (!this.memoryCache.TryGetValue<DateTime>("TimeNow", out var value))
            {
                Thread.Sleep(2000);
                value = DateTime.UtcNow;
                this.memoryCache.Set("TimeNow", value, TimeSpan.FromSeconds(10));
            }
            return this.Ok(value);
        }

        public IActionResult Index()
        {
            //PT: ORDERED BY IMPORTANCE:
            //1. this._logger.LogTrace();
            //2. this._logger.LogDebug();
            //3. this._logger.LogInformation();
            //4. this._logger.LogWarning();
            //5. this._logger.LogError();
            //6. this._logger.LogCritical();

            this._logger.LogWarning("Hello from Controller:HomeController / Action:Index()!");

            return View();
        }

        [Authorize]
        public IActionResult Chat()
        {
            return this.View();
        }

        //PT: ADD CROSS-ORIGIN RESOURCE SHARING /CORS/ LOCALLY, ON A CONTROLLER OR AN ACTION (3)
        //[EnableCors("AllowSpecificOrigin")]
        //[DisableCors]
        public IActionResult Privacy()
        {
            this._logger.LogWarning("Hello from Controller:HomeController / Action:Privacy()!");

            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Environment()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            this._logger.LogWarning("Hello from Controller:HomeController / Action:Error()!");

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}