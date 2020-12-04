using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using System;
using System.Threading.Tasks;

namespace PTSchool.Web.ApiControllers
{
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        [Route("api/Students")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1)
        {
            var students = await this.studentService.GetAllStudentsLightByPageAsync(page);

            return Ok(students);
        }

        [HttpGet]
        [Route("api/Students/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var student = await this.studentService.GetStudentFullByIdAsync(id);

            return Ok(student);
        }
    }
}
