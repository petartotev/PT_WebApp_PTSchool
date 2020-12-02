using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PTSchool.Services;
using PTSchool.Web.Hubs;
using PTSchool.Web.Models.Tictactoe;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
{
    [Authorize]
    public class TictactoeController : Controller
    {
        private readonly ITictactoeService tictactoeService;
        private readonly IHubContext<PlayHub> playHub;

        public TictactoeController(ITictactoeService tictactoeService, IHubContext<PlayHub> playHub)
        {
            this.tictactoeService = tictactoeService;
            this.playHub = playHub;
        }

        public IActionResult Menu()
        {
            return this.View();
        }


        public IActionResult Create()
        {
            Guid gameId = Guid.NewGuid();
            var nameAspNetUser1 = this.HttpContext.User.Identity.Name;
            this.tictactoeService.CreateNewGame(gameId, nameAspNetUser1);

            return RedirectToAction("Play", "Tictactoe", new { id = gameId, gameHost = nameAspNetUser1, nameUser = nameAspNetUser1 });
        }


        public IActionResult Play(string id, string gameHost, string nameUser)
        {
            var userGame = new UserGameViewModel
            {
                GameId = id,
                GameHost = gameHost,
                NameUser = nameUser
            };

            return this.View(userGame);
        }


        public IActionResult JoinPlay(Guid id, string gameHost)
        {
            Guid gameId = id;
            var nameAspNetUser2 = this.HttpContext.User.Identity.Name;

            var isMissionAccomplished = this.tictactoeService.JoinGame(gameId, nameAspNetUser2);

            if (isMissionAccomplished)
            {
                return RedirectToAction("Play", "Tictactoe", new { id = gameId, gameHost = gameHost, nameUser = nameAspNetUser2 });
            }
            else
            {
                return RedirectToAction("Busy", "Tictactoe");
            }
        }


        public async Task<IActionResult> Join()
        {
            var listAllGamesAvailable = await this.tictactoeService.GetAllGamesAvailableNotFinishedLast5MinutesAsync();

            var model = new CollectionTictactoeViewModels
            {
                GamesTictactoeAvailable = listAllGamesAvailable.Select(x => new TictactoeViewModel
                {
                    Id = x.Id,
                    User1Id = x.IdUser1,
                    User2Id = x.IdUser2,
                    DateCreated = x.DateCreated,
                    DateFinished = x.DateFinished,
                    IsFinished = x.IsFinished
                })
            };

            return this.View(model);
        }

        public IActionResult Busy()
        {
            return this.View();
        }
    }
}
