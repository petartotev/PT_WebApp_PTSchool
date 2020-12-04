using PTSchool.Web.Models.Abstracts;
using System;

namespace PTSchool.Web.Models.Club
{
    public class ClubLightViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsUnlisted { get; set; }
    }
}
