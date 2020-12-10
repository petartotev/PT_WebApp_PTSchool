using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSchool.Services.Contracts;
using PTSchool.Web.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
{
    [Authorize(Roles = "Teacher, Parent, Student")]
    public class TeachersController : Controller
    {
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;

        public TeachersController(ITeacherService teacherService, IMapper mapper)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
        }

        [Authorize(Roles = "Teacher, Parent, Student")]
        public async Task<IActionResult> AllTeachers(int page = 1)
        {
            var teachers = await this.teacherService.GetAllTeachersLightByPageAsync(page);

            var model = new CollectionTeachersLightViewModels
            {
                Teachers = this.mapper.Map<IEnumerable<TeacherLightViewModel>>(teachers),
                Url = "/Teachers/AllTeachers",
                TotalCount = teacherService.GetTotalCount(),
                PageSize = teacherService.GetPageSize(),
                CurrentPage = page,
            };

            return this.View(model);
        }

        [Authorize(Roles = "Teacher, Parent, Student")]
        public async Task<IActionResult> Teacher(Guid id)
        {
            var teacher = await this.teacherService.GetTeacherFullByIdAsync(id);

            var model = this.mapper.Map<TeacherFullViewModel>(teacher);

            return this.View(model);
        }
    }
}
