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
            var teachers = await this.teacherService.GetAllTeachersLightByPageAsync(page);

            return Ok(teachers);
        }

        [HttpGet]
        [Route("api/Teachers/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var teacher = await this.teacherService.GetTeacherFullByIdAsync(id);

            return Ok(teacher);
        }
    }
}
