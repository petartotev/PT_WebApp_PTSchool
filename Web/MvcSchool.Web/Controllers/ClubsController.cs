using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcSchool.Services;
using MvcSchool.Web.Models.Club;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Controllers
{
    [Authorize(Roles = "Teacher, Parent, Student")]
    public class ClubsController : Controller
    {
        private readonly IClubService clubService;

        public ClubsController(IClubService clubService)
        {
            this.clubService = clubService;
        }

        public async Task<IActionResult> AllClubs()
        {
            var allClubsFull = this.clubService.GetAllClubProfilesFull();

            var model = new AllClubProfilesFullViewModel
            {
                AllClubsFull = allClubsFull
            };

            return await Task.Run(() => View(model));
        }

        public async Task<IActionResult> Club(int id)
        {
            var clubById = this.clubService.GetClubProfileFullById(id);

            var model = new ClubProfileFullByClubIdViewModel
            {
                ClubProfileFull = clubById
            };

            return await Task.Run(() => this.View(model));
        }

        public int GetAllClubsCount()
        {
            var allClubsCount = this.clubService.GetAllClubsCount();

            return allClubsCount;
        }

        public int GetAllClubsStudentsCount()
        {
            var allClubsStudentsCount = this.clubService.GetAllClubsStudentsCount();

            return allClubsStudentsCount;
        }

        public int GetAllClubsTeachersCount()
        {
            var allClubsTeachersCount = this.clubService.GetAllClubsTeachersCount();

            return allClubsTeachersCount;
        }
    }
}
