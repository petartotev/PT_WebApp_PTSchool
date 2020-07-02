using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MvcSchool.Data;
using MvcSchool.Data.Models;
using MvcSchool.Services.Models.Tictactoe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcSchool.Services.Implementations
{
    public class TictactoeService : ITictactoeService
    {
        private readonly MvcSchoolDbContext db;

        public TictactoeService(MvcSchoolDbContext db)
        {
            this.db = db;
        }

        public void CreateNewGame(string gameId, string nameAspNetUser1)
        {
            this.db.Tictactoe.Add(new Tictactoe
            {
                Id = gameId,
                IdAspNetUser1 = nameAspNetUser1,
                DateTimeCreated = DateTime.UtcNow,
                IsFinished = false,
            });
            db.SaveChanges();
        }

        public IEnumerable<TictactoeServiceModel> GetAllGamesAvailableNotFinishedLast5Minutes()
        {
            var timeNow = DateTime.UtcNow;

            var listOfGamesUnfinishedInTheLast5Minutes = this.db
                .Tictactoe
                .Where(x => x.IsFinished == false)
                .Where(x => x.IdAspNetUser2 == null)
                //.Where(x => x.DateTimeCreated.CompareTo(DateTime.UtcNow) < 600)
                .Select(z => new TictactoeServiceModel
                {
                    Id = z.Id,
                    DateTimeCreated = z.DateTimeCreated,
                    IdAspNetUser1 = z.IdAspNetUser1,
                    IsFinished = z.IsFinished,
                })
                .OrderByDescending(x => x.DateTimeCreated);

            return listOfGamesUnfinishedInTheLast5Minutes;
        }

        public bool JoinGame(string gameId, string nameAspNetUser2)
        {
            if (this.db.Tictactoe.Where(x => x.Id == gameId).First().IdAspNetUser2 == null)
            {
                this.db.Tictactoe.Where(x => x.Id == gameId).FirstOrDefault().IdAspNetUser2 = nameAspNetUser2;
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
