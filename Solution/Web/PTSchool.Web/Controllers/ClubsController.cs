using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using PTSchool.Web.Models.Club;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
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
            var allClubsFull = this.clubService.GetAllClubs();

            var model = new CollectionClubsFullViewModels
            {
                AllClubsFull = allClubsFull
            };

            return await Task.Run(() => View(model));
        }

        public async Task<IActionResult> Club(int id)
        {
            var clubById = this.clubService.GetClubById(id);

            var model = new ClubByIdFullViewModel
            {
                ClubProfileFull = clubById
            };

            return await Task.Run(() => this.View(model));
        }

        public int GetAllClubsCount()
        {
            var allClubsCount = this.clubService.GetCountAllClubs();

            return allClubsCount;
        }

        public int GetAllClubsStudentsCount()
        {
            var allClubsStudentsCount = this.clubService.GetCountAllStudentsInClubs();

            return allClubsStudentsCount;
        }

        public int GetAllClubsTeachersCount()
        {
            var allClubsTeachersCount = this.clubService.GetCountAllTeachersInClubs();

            return allClubsTeachersCount;
        }
    }
}
