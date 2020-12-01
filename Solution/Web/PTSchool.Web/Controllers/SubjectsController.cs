using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using PTSchool.Web.Models.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
{
    [Authorize(Roles = "Teacher, Parent, Student")]
    public class SubjectsController : Controller
    {
        private readonly ISubjectService subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        public IActionResult AllSubjects()
        {
            var allSubjects = this.subjectService.GetAllSubjects();

            var model = new CollectionSubjectsFullViewModels
            {
                AllSubjectsFull = allSubjects
            };

            return this.View(model);
        }

        public IActionResult Subject(int id)
        {
            var subjectById = this.subjectService.GetSubjectById(id);

            var model = new SubjectByIdFullViewModel
            {
                SubjectProfileFullById = subjectById
            };

            return this.View(model);
        }
    }
}
