using PTSchool.Services.Models.Club;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Models.Club
{
    public class CollectionClubsFullViewModels
    {
        public IEnumerable<ClubFullServiceModel> AllClubsFull { get; set; }
    }
}
