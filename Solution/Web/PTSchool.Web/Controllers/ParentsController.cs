﻿using AutoMapper;
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
        private readonly IMapper mapper;

        public ParentsController(IParentService parentService, IMapper mapper)
        {
            this.parentService = parentService;
            this.mapper = mapper;
        }

        [Authorize(Roles = "Teacher, Parent")]
        [RequestSizeLimit(50 * 1024 * 1024)] // LIMIT BODY: 50MB
        public async Task<IActionResult> AllParents(int page = 1)
        {
            var parents = await this.parentService.GetAllParentsAsync(page);

            var model = new CollectionParentsLightViewModels
            {
                Parents = this.mapper.Map<IEnumerable<ParentLightViewModel>>(parents),
                Url = "/Parents/AllParents",
                TotalCount = parentService.GetTotalCount(),
                PageSize = parentService.GetPageSize(),
                CurrentPage = page,
            };

            return await Task.Run(() => this.View(model));
        }

        [Authorize(Roles = "Teacher, Parent")]
        public async Task<IActionResult> Parent(Guid id)
        {
            var parent = await parentService.GetParentByIdAsync(id);

            var model = this.mapper.Map<ParentLightViewModel>(parent);

            return this.View(model);
        }
    }
}
