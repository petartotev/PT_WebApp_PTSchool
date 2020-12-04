using Microsoft.AspNetCore.Mvc;
using PTSchool.Services.Implementations;
using System;
using System.Threading.Tasks;

namespace PTSchool.Web.ApiControllers
{
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private ITeacherService teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpGet]
        [Route("api/Teachers")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1)
        {
            var teachersToGet = await this.teacherService.GetAllTeachersLightByPageAsync(page);

            return Ok(teachersToGet);
        }

        [HttpGet]
        [Route("api/Teachers/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var teacherToGet = await this.teacherService.GetTeacherFullByIdAsync(id);

            return Ok(teacherToGet);
        }

        [HttpDelete]
        [Route("api/Teachers/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            bool isTeacherDeleted = await this.teacherService.DeleteTeacherByIdAsync(id);

            if (!isTeacherDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
