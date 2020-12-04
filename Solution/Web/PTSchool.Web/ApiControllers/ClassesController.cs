using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using PTSchool.Services.Models.Class;
using System;
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
            var classesToGet = await this.classService.GetAllClassesLightByPageAsync(page);

            return Ok(classesToGet);
        }

        [HttpGet]
        [Route("api/Classes/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var classToGet = await this.classService.GetClassFullByIdAsync(id);

            return Ok(classToGet);
        }

        [HttpDelete]
        [Route("api/Classes/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isClassDeleted = await this.classService.DeleteClassByIdAsync(id);

            if (!isClassDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/Classes/{id}")]
        public async Task<IActionResult> Update([FromBody] ClassFullServiceModel classToUpdate)
        {
            var classUpdated = await this.classService.UpdateClassAsync(classToUpdate);

            return Ok(classUpdated);
        }
    }
}
