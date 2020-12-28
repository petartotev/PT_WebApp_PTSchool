using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache memoryCache;
        private readonly IHomeService homeService;
        private readonly IMapper mapper;

        // PT: INJECT IMemoryCache FOR CACHE
        public HomeController(IMemoryCache memoryCache, IHomeService homeService, IMapper mapper)
        {
            this.memoryCache = memoryCache;
            this.homeService = homeService;
            this.mapper = mapper;
        }

        public IActionResult RegisterPolicy()
        {
            return this.View();
        }

        public async Task<IActionResult> Index()
        {
            HomeServiceModel homeServiceModel = await homeService.GetHomePageInformationPackage();
            HomeViewModel model = this.mapper.Map<HomeViewModel>(homeServiceModel);

            WeatherViewModel weather = this.mapper.Map<WeatherViewModel>(homeServiceModel.RootWeather);
            model.Weather = weather;

            if (!this.memoryCache.TryGetValue<DateTime>("TimeNow", out var value))
            {
                value = DateTime.UtcNow;
                this.memoryCache.Set("TimeNow", value, TimeSpan.FromSeconds(10));

                //// PT: Every time someone gets this cached value its expiration will expand with (0,10,0) minutes.
                //this.memoryCache.Set("TimeNow", value, new MemoryCacheEntryOptions
                //{
                //    SlidingExpiration = new TimeSpan(0, 10, 0)
                //});
            }
            model.TimeNow = value;

            return View(model);
        }

        [Authorize]
        public IActionResult Chat()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PageNotFound()
        {
            return View();
        }

        public IActionResult About()
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

        public IActionResult EmailError()
        {
            return this.View();
        }
    }
}