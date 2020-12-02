using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using PTSchool.Web.Models.Student;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
{
    [Authorize(Roles = "Teacher, Parent, Student")]
    public class StudentsController : Controller
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;

        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }

        [Authorize(Roles = "Teacher, Parent, Student")]
        public async Task<IActionResult> AllStudents(int page = 1)
        {
            var students = await this.studentService.GetAllStudentsAsync(page);

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
        //[Authorize(Roles = "Teacher, Parent, Student")]
        //public async Task<IActionResult> AllStudents(CollectionStudentsLightViewModels model)
        //{
        //    return this.View(model);
        //}

        public async Task<IActionResult> Student(Guid id)
        {
            var student = await this.studentService.GetStudentByIdAsync(id);

            var model = this.mapper.Map<StudentLightViewModel>(student);

            return this.View(model);
        }
    }
}
