using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using PTSchool.Web.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
{
    [Authorize(Roles = "Teacher, Parent, Student")]
    public class ClassesController : Controller
    {
        private readonly IClassService classService;

        public ClassesController(IClassService classService)
        {
            this.classService = classService;
        }


        public async Task<IActionResult> AllClasses()
        {
            var allClasses = this.classService.GetAllClasses();

            var model = new CollectionClassesFullViewModels
            {
                AllClassesFull = allClasses
            };

            return await Task.Run(() => this.View(model));
        }

        public async Task<IActionResult> Class(int id)
        {
            var classById = this.classService.GetClassById(id);

            var model = new ClassByIdFullViewModel();

            model.classProfile = classById;

            return await Task.Run(() => this.View(model));
        }
    }
}
