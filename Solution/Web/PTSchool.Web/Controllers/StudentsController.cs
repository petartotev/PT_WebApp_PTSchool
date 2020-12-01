using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using PTSchool.Services.Implementations;
using PTSchool.Services.Models.Student;
using PTSchool.Web.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
{
    [Authorize(Roles = "Teacher, Parent, Student")]
    public class StudentsController : Controller
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [Authorize(Roles = "Teacher, Parent, Student")]
        public IActionResult AllStudents()
        {
            var allStudentProfilesFullService = this.studentService.GetAllStudents();

            var model = new CollectionStudentsFullViewModels
            {
                AllStudentsFull = allStudentProfilesFullService,
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher, Parent, Student")]
        public IActionResult AllStudents(CollectionStudentsFullViewModels model)
        {
            int orderByMethod = (int)model.OrderByMethod;
            int ascendingOrDescending = (int)model.AscendingOrDescending;

            var allStudentsOrdered = this.studentService.GetAllStudentProfilesFullOrdered(orderByMethod, ascendingOrDescending);

            model.AllStudentsFull = allStudentsOrdered;

            return this.View(model);
        }

        [Authorize(Roles = "Teacher, Parent, Student")]
        public IActionResult AllStudentsByGender(int id)
        {
            var allStudentProfilesFullServiceByGender = this.studentService.GetAllStudentsByGender(id);

            var model = new CollectionStudentsFullViewModels
            {
                AllStudentsFull = allStudentProfilesFullServiceByGender
            };

            return View("AllStudents", model);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher, Parent, Student")]
        public IActionResult AllStudentsByGender(int id, CollectionStudentsFullViewModels model)
        {
            int orderByMethod = (int)model.OrderByMethod;
            int ascendingOrDescending = (int)model.AscendingOrDescending;

            var allStudentsByGenderOrdered = this.studentService.GetAllStudentProfilesFullByGenderOrdered(id, orderByMethod, ascendingOrDescending);

            model.AllStudentsFull = allStudentsByGenderOrdered;

            return View("AllStudents", model);
        }

        [Authorize(Roles = "Teacher, Parent, Student")]
        public IActionResult AllStudentsBirthday()
        {
            var allStudentProfilesFullServiceByBirthday = this.studentService.GetAllStudentsThatHaveBirthdayToday();

            var model = new CollectionStudentsFullViewModels
            {
                AllStudentsFull = allStudentProfilesFullServiceByBirthday
            };

            return View("AllStudents", model);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher, Parent, Student")]
        public IActionResult AllStudentsBirthday(CollectionStudentsFullViewModels model)
        {
            int orderByMethod = (int)model.OrderByMethod;
            int ascendingOrDescending = (int)model.AscendingOrDescending;

            var allStudentsByBirthdayOrdered = this.studentService.GetAllStudentProfilesFullByDateOfBirthTodayOrdered(orderByMethod, ascendingOrDescending);

            model.AllStudentsFull = allStudentsByBirthdayOrdered;

            return View("AllStudents", model);
        }

        [Authorize(Roles = "Teacher, Parent, Student")]
        public IActionResult AllStudentsByYear(int id)
        {
            var allStudentProfilesFullServiceByYear = this.studentService.GetAllStudentsByYear(id);

            var model = new CollectionStudentsFullViewModels
            {
                AllStudentsFull = allStudentProfilesFullServiceByYear
            };

            return View("AllStudents", model);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher, Parent, Student")]
        public IActionResult AllStudentsByYear(int id, CollectionStudentsFullViewModels model)
        {
            int orderByMethod = (int)model.OrderByMethod;
            int ascendingOrDescending = (int)model.AscendingOrDescending;

            var allStudentsByYearOrdered = this.studentService.GetAllStudentProfilesFullByYearOrdered(id, orderByMethod, ascendingOrDescending);

            model.AllStudentsFull = allStudentsByYearOrdered;

            return View("AllStudents", model);
        }

        public IActionResult AllStudentsByClass(int id)
        {
            var allStudentProfilesFullServiceByClass = this.studentService.GetAllStudentsByClassId(id);

            var model = new CollectionStudentsFullViewModels
            {
                AllStudentsFull = allStudentProfilesFullServiceByClass
            };

            return View("AllStudents", model);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher, Parent, Student")]
        public IActionResult AllStudentsByClass(int id, CollectionStudentsFullViewModels model)
        {
            int orderByMethod = (int)model.OrderByMethod;
            int ascendingOrDescending = (int)model.AscendingOrDescending;

            var allStudentsByClassOrdered = this.studentService.GetAllStudentProfilesFullByClassOrdered(id, orderByMethod, ascendingOrDescending);

            model.AllStudentsFull = allStudentsByClassOrdered;

            return View("AllStudents", model);
        }

        public IActionResult Student(int id)
        {
            var studentProfileFull = this.studentService.GetStudentById(id);

            var model = new StudentByIdFullViewModel
            {
                StudentProfileFull = studentProfileFull
            };

            return this.View(model);
        }
    }
}
