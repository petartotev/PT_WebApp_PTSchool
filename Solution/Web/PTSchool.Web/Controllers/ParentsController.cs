using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using PTSchool.Web.Models.Class;
using PTSchool.Web.Models.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
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
            var allParentsFullProfile = this.parentService.GetAllParents(page);

            var totalParents = this.parentService.GetCountAllParents();

            var model = new CollectionParentsFullViewModels
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
            var parentProfileFullById = parentService.GetParentById(id);

            var model = new ParentByIdFullViewModel
            {
                ParentProfileFull = parentProfileFullById,
                Test = page,
            };

            return this.View(model);
        }
    }
}
