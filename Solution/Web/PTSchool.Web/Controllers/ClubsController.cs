using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSchool.Services.Contracts;
using PTSchool.Web.Models.Club;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
{
    [Authorize(Roles = "Teacher, Parent, Student")]
    public class ClubsController : Controller
    {
        private readonly IClubService clubService;
        private readonly IMapper mapper;
        public ClubsController(IClubService clubService, IMapper mapper)
        {
            this.clubService = clubService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> AllClubs(int page = 1)
        {
            var clubs = await this.clubService.GetAllClubsLightByPageAsync(page);

            var model = new CollectionClubsFullViewModels
            {
                Clubs = this.mapper.Map<IEnumerable<ClubLightViewModel>>(clubs),
                Url = "/Clubs/AllClubs",
                PageSize = clubService.GetPageSize(),
                TotalCount = clubService.GetTotalCount(),
                CurrentPage = page
            };

            return await Task.Run(() => View(model));
        }

        public async Task<IActionResult> Club(Guid id)
        {
            var club = await this.clubService.GetClubFullByIdAsync(id);

            var model = this.mapper.Map<ClubFullViewModel>(club);

            return await Task.Run(() => this.View(model));
        }
    }
}
