using PTSchool.Data.Models;
using PTSchool.Services.Models.Tictactoe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PTSchool.Services
{
    public interface ITictactoeService
    {
        Task<IEnumerable<TictactoeServiceModel>> GetAllGamesAvailableNotFinishedLast5MinutesAsync();

        void CreateNewGame(Guid gameId, string nameAspNetUser1);

        bool JoinGame(Guid gameId, string nameAspNetUser2);

        void RegisterFinishedGame();
    }
}
