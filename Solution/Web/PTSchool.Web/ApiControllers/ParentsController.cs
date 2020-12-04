using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using System;
using System.Threading.Tasks;

namespace PTSchool.Web.ApiControllers
{
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IParentService parentService;

        public ParentsController(IParentService parentService)
        {
            this.parentService = parentService;
        }

        [HttpGet]
        [Route("api/Parents")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1)
        {
            var parents = await this.parentService.GetAllParentsLightByPageAsync(page);

            return Ok(parents);
        }

        [HttpGet]
        [Route("api/Parents/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var parent = await this.parentService.GetParentFullByIdAsync(id);

            return Ok(parent);
        }
    }
}
