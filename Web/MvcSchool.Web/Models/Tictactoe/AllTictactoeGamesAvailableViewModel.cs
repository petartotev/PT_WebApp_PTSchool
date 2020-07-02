using MvcSchool.Services.Models.Tictactoe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Models.Tictactoe
{
    public class AllTictactoeGamesAvailableViewModel
    {
        public IEnumerable<TictactoeServiceModel> AllTictactoeGamesAvailable { get; set; }
    }
}
