using Microsoft.AspNetCore.Mvc;
using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Teacher;
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
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isTeacherDeleted = await this.teacherService.DeleteTeacherByIdAsync(id);

            if (!isTeacherDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/Teachers/{id}")]
        public async Task<IActionResult> Update([FromBody] TeacherFullServiceModel teacher)
        {
            var teacherUpdated = await this.teacherService.UpdateTeacherAsync(teacher);

            return Ok(teacherUpdated);
        }

        [HttpPost]
        [Route("api/Teachers")]
        public async Task<IActionResult> Post([FromBody] TeacherFullServiceModel teacher)
        {
            var teacherCreated = await this.teacherService.CreateTeacherAsync(teacher);

            return Ok(teacherCreated);
        }
    }
}
