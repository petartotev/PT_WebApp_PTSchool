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
            var parentsToGet = await this.parentService.GetAllParentsLightByPageAsync(page);

            return Ok(parentsToGet);
        }

        [HttpGet]
        [Route("api/Parents/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var parentToGet = await this.parentService.GetParentFullByIdAsync(id);

            return Ok(parentToGet);
        }

        [HttpDelete]
        [Route("api/Parents/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            bool isParentDeleted = await this.parentService.DeleteParentByIdAsync(id);

            if (!isParentDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
