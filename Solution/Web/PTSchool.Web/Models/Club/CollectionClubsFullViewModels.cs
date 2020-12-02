using PTSchool.Web.Models.Abstracts;
using System.Collections.Generic;

namespace PTSchool.Web.Models.Club
{
    public class CollectionClubsFullViewModels : PageableCollection
    {
        public IEnumerable<ClubLightViewModel> Clubs { get; set; }
    }
}
