using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcSchool.Services;
using MvcSchool.Web.Models.Class;
using MvcSchool.Web.Models.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace MvcSchool.Web.Controllers
{
    [Authorize(Roles = "Teacher, Parent")]
    public class ParentsController : Controller
    {
        private readonly IParentService parentService;

        public ParentsController(IParentService parentService)
        {
            this.parentService = parentService;
        }

        [Authorize(Roles = "Teacher, Parent")]
        [RequestSizeLimit(50 * 1024 * 1024)] // LIMIT BODY: 50MB
        public async Task<IActionResult> AllParents(int page = 1)
        {
            var allParentsFullProfile = this.parentService.GetAllParentProfilesFull(page);

            var totalParents = this.parentService.Total();

            var model = new AllParentProfilesFullViewModel
            {
                AllParentsFull = allParentsFullProfile,
                CurrentPage = page,
                Total = totalParents,
            };

            return await Task.Run(() => this.View(model));
        }

        [Authorize(Roles = "Teacher, Parent")]
        public IActionResult Parent(int id, int page = 1)
        {
            var parentProfileFullById = parentService.GetParentProfileFullById(id);

            var model = new ParentProfileFullByParentIdViewModel
            {
                ParentProfileFull = parentProfileFullById,
                Test = page,
            };

            return this.View(model);
        }
    }
}
