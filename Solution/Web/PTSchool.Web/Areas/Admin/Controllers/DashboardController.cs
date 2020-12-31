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