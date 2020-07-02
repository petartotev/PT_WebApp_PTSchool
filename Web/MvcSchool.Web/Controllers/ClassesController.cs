using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcSchool.Services;
using MvcSchool.Web.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Controllers
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
            var allClasses = this.classService.GetAllClassProfilesFull();

            var model = new AllClassProfilesFullViewModel
            {
                AllClassesFull = allClasses
            };

            return await Task.Run(() => this.View(model));
        }

        public async Task<IActionResult> Class(int id)
        {
            var classById = this.classService.GetClassProfileFullById(id);

            var model = new ClassProfileFullByClassIdViewModel();

            model.classProfile = classById;

            return await Task.Run(() => this.View(model));
        }
    }
}
