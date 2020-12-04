using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using System;
using System.Threading.Tasks;

namespace PTSchool.Web.ApiControllers
{
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private ISubjectService subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [HttpGet]
        [Route("api/Subjects")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1)
        {
            var clubs = await this.subjectService.GetAllSubjectsLightByPageAsync(page);

            return Ok(clubs);
        }

        [HttpGet]
        [Route("api/Subjects/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var club = await this.subjectService.GetSubjectFullByIdAsync(id);

            return Ok(club);
        }
    }
}
