using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSchool.Services.Contracts;
using PTSchool.Web.Models.Subject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
{
    [Authorize(Roles = "Teacher, Parent, Student")]
    public class SubjectsController : Controller
    {
        private readonly ISubjectService subjectService;
        private readonly IMapper mapper;

        public SubjectsController(ISubjectService subjectService, IMapper mapper)
        {
            this.subjectService = subjectService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> AllSubjects(int page = 1)
        {
            var subjects = await this.subjectService.GetAllSubjectsLightByPageAsync(page);

            var model = new CollectionSubjectsFullViewModels
            {
                Subjects = this.mapper.Map<IEnumerable<SubjectLightViewModel>>(subjects),
                Url = "/Subjects/AllSubjects",
                PageSize = subjectService.GetPageSize(),
                TotalCount = subjectService.GetTotalCount(),
                CurrentPage = page
            };

            return this.View(model);
        }

        public async Task<IActionResult> Subject(Guid id)
        {
            var subject = await this.subjectService.GetSubjectFullByIdAsync(id);

            var model = this.mapper.Map<SubjectFullViewModel>(subject);

            return this.View(model);
        }
    }
}
