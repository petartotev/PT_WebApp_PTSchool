using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using PTSchool.Services.Models.Class;
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
        private readonly IMapper mapper;

        public ClassesController(IClassService classService, IMapper mapper)
        {
            this.classService = classService;
            this.mapper = mapper;
        }


        public async Task<IActionResult> AllClasses(int page = 1)
        {
            IEnumerable<ClassLightServiceModel> classes = await this.classService.GetAllClassesAsync(page);

            var model = new CollectionClassesLightViewModels
            {
                Classes = this.mapper.Map<IEnumerable<ClassLightViewModel>>(classes),
                Url = "/Classes/AllClasses",
                PageSize = classService.GetPageSize(),
                TotalCount = classService.GetTotalCount(),
                CurrentPage = page
            };

            return await Task.Run(() => this.View(model));
        }

        public async Task<IActionResult> Class(Guid id)
        {
            var classById = await this.classService.GetClassByIdAsync(id);

            var model = this.mapper.Map<ClassFullViewModel>(classById);

            return await Task.Run(() => this.View(model));
        }
    }
}
