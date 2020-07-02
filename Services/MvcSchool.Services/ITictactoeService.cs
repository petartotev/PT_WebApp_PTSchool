using MvcSchool.Data.Models;
using MvcSchool.Services.Models.Tictactoe;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Services
{
    public interface ITictactoeService
    {
        IEnumerable<TictactoeServiceModel> GetAllGamesAvailableNotFinishedLast5Minutes();

        void CreateNewGame(string gameId, string nameAspNetUser1);

        bool JoinGame(string gameId, string nameAspNetUser2);

        void RegisterFinishedGame();
    }
}
