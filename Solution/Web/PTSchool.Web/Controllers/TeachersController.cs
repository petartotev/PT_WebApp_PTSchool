using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PTSchool.Services.Implementations;
using PTSchool.Web.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
{
    [Authorize(Roles = "Teacher, Parent, Student")]
    public class TeachersController : Controller
    {
        private readonly ITeacherService teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [Authorize(Roles = "Teacher, Parent, Student")]
        public IActionResult AllTeachers(int page = 1)
        {
            var teacherProfilesFull = this.teacherService.GetAllTeacherProfilesFull(page);
            var pageSizeCount = this.teacherService.GetPageCountSizing();
            var totalCount = this.teacherService.GetTotalTeachersCount();

            var model = new CollectionTeachersFullViewModels
            {
                AllTeachersFull = teacherProfilesFull,
                PageSize = pageSizeCount,
                CurrentPage = page,
                TotalCount = totalCount,
            };

            return this.View(model);
        }

        [Authorize(Roles = "Teacher, Parent, Student")]
        public IActionResult Teacher(int id)
        {
            var teacherProfileFullById = this.teacherService.GetTeacherProfileFullById(id);

            var model = new TeacherByIdFullViewModel
            {
                TeacherProfileFullById = teacherProfileFullById
            };

            return this.View(model);
        }
    }
}
