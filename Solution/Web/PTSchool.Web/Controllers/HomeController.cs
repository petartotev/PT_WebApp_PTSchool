using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Home;
using PTSchool.Web.Models;
using PTSchool.Web.Models.Home;
using System;
using System.Diagnostics;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;
        private readonly IHomeService homeService;
        private readonly IMapper mapper;

        // PT: CACHE (IN-MEMORY CACHING) - inject IMemoryCache interface (step 2)
        // PT: CACHE (DISTRIBUTED CACHING - SQLSERVER) - inject IDistributedCache interface (step 3)
        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache, IDistributedCache distributedCache, IHomeService homeService, IMapper mapper)
        {
            this.logger = logger;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
            this.homeService = homeService;
            this.mapper = mapper;
        }

        // PT: CACHE (RESPONSE CACHING - RECOMMENDED TO BROWSER) (step 3):
        //[ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60 /*sec*/ * 10 /*min*/)]
        public async Task<IActionResult> Index()
        {
            this.logger.LogCritical("Hello");

            HomeServiceModel homeServiceModel = await homeService.GetHomePageInformationPackage();
            HomeViewModel model = this.mapper.Map<HomeViewModel>(homeServiceModel);

            WeatherViewModel weather = this.mapper.Map<WeatherViewModel>(homeServiceModel.RootWeather);
            model.Weather = weather;

            // PT: CACHE (IN-MEMORY CACHING) (step 3)
            if (!this.memoryCache.TryGetValue<DateTime>("TimeNowInMemory", out var valueInMemory))
            {
                valueInMemory = DateTime.UtcNow;
                this.memoryCache.Set("TimeNowInMemory", valueInMemory, TimeSpan.FromSeconds(10));

                //// PT: Every time someone gets this cached value its expiration will expand with (0,10,0) minutes.
                //this.memoryCache.Set("TimeNow", value, new MemoryCacheEntryOptions
                //{
                //    SlidingExpiration = new TimeSpan(0, 10, 0)
                //});
            }
            model.TimeNowCachedInMemory = valueInMemory;

            // PT: CACHE (DISTRIBUTED CACHING - SQLSERVER) (step 4)
            var valueDistributed = await this.distributedCache.GetStringAsync("TimeNowDistributed");
            if (valueDistributed == null)
            {
                valueDistributed = DateTime.UtcNow.ToString();
                await this.distributedCache.SetStringAsync("TimeNowDistributed", valueDistributed, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });
            }
            model.TimeNowCachedDistributed = DateTime.Parse(valueDistributed);

            // PT: SESSION / COOKIES (step 4)
            string id = this.HttpContext.Session.Id;
            this.HttpContext.Session.SetString("TestSession", "SessionValueOrWhatever");
            string valueSession = this.HttpContext.Session.GetString("TestSession");

            // PT: TEMP DATA
            this.TempData["TempDataTest"] = "This is just a test on TempData.";
            // Once read TempData is cleared.

            return View(model);
        }

        [Authorize]
        public IActionResult Chat()
        {
            return this.View();
        }

        public IActionResult EmailError()
        {
            return this.View();
        }

        public IActionResult EmailSend()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult EmailSend(EmailSendViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        EmailSendServiceModel modelService = new EmailSendServiceModel
                        {
                            Subject = model.Subject,
                            Message = model.Message,
                        };

                        var isEmailSent = homeService.SendEmail(modelService);

                        if (isEmailSent)
                        {
                            return RedirectToAction("EmailSuccess", "Home");
                        }
                        else
                        {
                            return RedirectToAction("EmailError", "Home");
                        }
                    }
                    catch (SmtpException ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }

            return View();
        }

        public IActionResult EmailSuccess()
        {
            return this.View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return this.View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RegisterPolicy()
        {
            return this.View();
        }
    }
}