using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Dashboard : Controller
    {
        public Dashboard()
        {

        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
