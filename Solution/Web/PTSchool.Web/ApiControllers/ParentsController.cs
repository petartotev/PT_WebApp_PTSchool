using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using PTSchool.Services.Models.Parent;
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
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isParentDeleted = await this.parentService.DeleteParentByIdAsync(id);

            if (!isParentDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/Parents/{id}")]
        public async Task<IActionResult> Put([FromBody] ParentFullServiceModel parent)
        {
            var parentUpdated = await this.parentService.UpdateParentAsync(parent);

            return Ok(parentUpdated);
        }

        [HttpPost]
        [Route("api/Parents")]
        public async Task<IActionResult> Post([FromBody] ParentFullServiceModel parent)
        {
            var parentCreated = await this.parentService.CreateParentAsync(parent);

            return Ok(parentCreated);
        }
    }
}
