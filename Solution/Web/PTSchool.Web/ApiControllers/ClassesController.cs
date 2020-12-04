using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.ApiControllers
{
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private IClassService classService;

        public ClassesController(IClassService classService)
        {
            this.classService = classService;
        }

        [HttpGet]
        [Route("api/Classes")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1)
        {
            var classes = await this.classService.GetAllClassesLightByPageAsync(page);

            return Ok(classes);
        }

        [HttpGet]
        [Route("api/Classes/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var classy = await this.classService.GetClassFullByIdAsync(id);

            return Ok(classy);
        }
    }
}
