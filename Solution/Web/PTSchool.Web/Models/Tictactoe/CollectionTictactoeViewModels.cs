using PTSchool.Web.Models.Tictactoe;
using System.Collections.Generic;

namespace PTSchool.Web.Models.Tictactoe
{
    public class CollectionTictactoeViewModels
    {
        public IEnumerable<TictactoeViewModel> AllTictactoeGamesAvailable { get; set; }
    }
}
