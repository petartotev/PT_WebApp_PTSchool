using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Data.Models;
using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Tictactoe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Services
{
    public class TictactoeService : ITictactoeService
    {
        private readonly PTSchoolDbContext db;
        private readonly IMapper mapper;

        public TictactoeService(PTSchoolDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void CreateNewGame(Guid gameId, string nameAspNetUser1)
        {
            this.db.Tictactoe.Add(new Tictactoe
            {
                Id = gameId,
                IdUser1 = nameAspNetUser1,
                DateCreated = DateTime.UtcNow,
                IsFinished = false,
            });
            db.SaveChanges();
        }

        public async Task<IEnumerable<TictactoeServiceModel>> GetAllGamesAvailableNotFinishedLast5MinutesAsync()
        {
            var games = await this.db.Tictactoe
                .Where(x => x.IsFinished == false)
                .Where(x => x.IdUser2 == null)
                .OrderByDescending(x => x.DateCreated)
                .ToListAsync();

            return this.mapper.Map<IEnumerable<TictactoeServiceModel>>(games);
        }

        public bool JoinGame(Guid gameId, string nameAspNetUser2)
        {
            if (this.db.Tictactoe.Where(x => x.Id == gameId).First().IdUser2 == null)
            {
                this.db.Tictactoe.Where(x => x.Id == gameId).FirstOrDefault().IdUser2 = nameAspNetUser2;
                this.db.SaveChanges();
                return true;
            }
            return false;
        }

        public void RegisterFinishedGame()
        {
            throw new NotImplementedException();
        }
    }
}
