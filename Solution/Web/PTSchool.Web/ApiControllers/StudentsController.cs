using Microsoft.AspNetCore.Mvc;
using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Student;
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
            var studentsToGet = await this.studentService.GetAllStudentsLightByPageAsync(page);

            return Ok(studentsToGet);
        }

        [HttpGet]
        [Route("api/Students/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var studentToGet = await this.studentService.GetStudentFullByIdAsync(id);

            return Ok(studentToGet);
        }

        [HttpDelete]
        [Route("api/Students/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isStudentDeleted = await this.studentService.DeleteStudentByIdAsync(id);

            if (!isStudentDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/Students/{id}")]
        public async Task<IActionResult> Put([FromBody] StudentFullServiceModel student)
        {
            var studentUpdated = await this.studentService.UpdateStudentAsync(student);

            return Ok(studentUpdated);
        }

        [HttpPost]
        [Route("api/Students")]
        public async Task<IActionResult> Post([FromBody] StudentFullServiceModel student)
        {
            var studentCreated = await this.studentService.CreateStudentAsync(student);

            return Ok(studentCreated);
        }
    }
}
