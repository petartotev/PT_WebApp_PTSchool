using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSchool.Services.Contracts;
using PTSchool.Web.Models.Student;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
{
    [Authorize(Roles = "Admin, Teacher, Parent, Student")]
    public class StudentsController : Controller
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;

        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }

        [Authorize(Roles = "Admin, Teacher, Parent, Student")]
        public async Task<IActionResult> AllStudents(int page = 1)
        {
            var students = await this.studentService.GetAllStudentsLightByPageAsync(page);

            var model = new CollectionStudentsLightViewModels
            {
                Students = this.mapper.Map<IEnumerable<StudentLightViewModel>>(students),
                Url = "/Students/AllStudents",
                TotalCount = studentService.GetTotalCount(),
                PageSize = studentService.GetPageSize(),
                CurrentPage = page,
            };

            return this.View(model);
        }

        //[HttpPost]
        //[Authorize(Roles = "Admin, Teacher, Parent, Student")]
        //public async Task<IActionResult> AllStudents(CollectionStudentsLightViewModels model)
        //{
        //    return this.View(model);
        //}

        public async Task<IActionResult> Student(Guid id)
        {
            var student = await this.studentService.GetStudentFullByIdAsync(id);

            var model = this.mapper.Map<StudentFullViewModel>(student);

            return this.View(model);
        }

        public async Task<IActionResult> StudentCouncil()
        {
            var studentCouncilMembers = await this.studentService.GetAllStudentCouncilMembersAsync();

            var model = this.mapper.Map<IEnumerable<StudentFullViewModel>>(studentCouncilMembers);

            return await Task.Run(() => this.View(model));
        }
    }
}
