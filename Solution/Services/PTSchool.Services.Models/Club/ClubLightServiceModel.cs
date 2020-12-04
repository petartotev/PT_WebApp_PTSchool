using System;

namespace PTSchool.Services.Models.Club
{
    public class ClubLightServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsUnlisted { get; set; }
    }
}
