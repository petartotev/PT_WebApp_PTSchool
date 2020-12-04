using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
{
    public class ApiServicesController : Controller
    {
        public ApiServicesController()
        {
        }

        public async Task<IActionResult> General()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> Documentation()
        {
            return await Task.Run(() => View());
        }
    }
}
