using PTSchool.Data.Models;
using PTSchool.Services.Models.Tictactoe;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services
{
    public interface ITictactoeService
    {
        IEnumerable<TictactoeServiceModel> GetAllGamesAvailableNotFinishedLast5Minutes();

        void CreateNewGame(string gameId, string nameAspNetUser1);

        bool JoinGame(string gameId, string nameAspNetUser2);

        void RegisterFinishedGame();
    }
}
