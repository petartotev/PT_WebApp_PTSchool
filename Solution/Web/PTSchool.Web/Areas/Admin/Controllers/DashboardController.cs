using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// PT: AREAS (step 2 - Areas(Folder) -> r.cl. -> Add -> |Area...| -> Create ...)
// PT: AREAS (step 3 - Create Controller -> DashboardController : Controller)

namespace PTSchool.Web.Areas.Admin.Controllers
{
    // PT: AREAS (step 4 - Put Attribute [Area("Admin")] on Controller)
    [Area("Admin")]     
    public class DashboardController : Controller
    {
        public DashboardController()
        {
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Environment()
        {
            return this.View();
        }

        // PT: AREAS (step 5 - Create new Action Index() => return this.View())   
        public IActionResult Index()
        {
            return this.View();
        }
    }
}

// PT: AREAS (step 5 - Copy the 2 files from Projects' Views(Folder) - _ViewImports.cshtml, _ViewStart.cshtml)
// PT: AREAS (step 6 - Paste the 2 files here: Areas(Folder) -> Admin(Folder) -> Views(Folder))
// PT: AREAS (step 7 - Now you can access it here: https://localhost:5001/Admin/Dashboard/Index/1)