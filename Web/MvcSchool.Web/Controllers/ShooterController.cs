using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Controllers
{
    [Authorize]
    public class ShooterController : Controller
    {
        public IActionResult Play()
        {
            return this.View();
        }
    }
}
