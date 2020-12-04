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
        public async Task<IActionResult> DeleteById(Guid id)
        {
            bool isStudentDeleted = await this.studentService.DeleteStudentByIdAsync(id);

            if (!isStudentDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
