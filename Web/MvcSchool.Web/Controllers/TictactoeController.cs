using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MvcSchool.Services;
using MvcSchool.Web.Hubs;
using MvcSchool.Web.Models.Chat;
using MvcSchool.Web.Models.Tictactoe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Controllers
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
            string gameId = Guid.NewGuid().ToString();
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
        

        public IActionResult JoinPlay(string id, string gameHost)
        {            
            string gameId = id;
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


        public IActionResult Join()
        {
            var listAllGamesAvailable = this.tictactoeService.GetAllGamesAvailableNotFinishedLast5Minutes();

            var model = new AllTictactoeGamesAvailableViewModel
            {
                AllTictactoeGamesAvailable = listAllGamesAvailable
            };

            return this.View(model);
        }

        public IActionResult Busy()
        {
            return this.View();
        }
    }
}
