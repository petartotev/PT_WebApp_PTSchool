using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PTSchool.Data.Models.Validations.StaticValidator.Club;

namespace PTSchool.Data.Models
{
    public class Club
    {
        // GENERAL
        public Guid Id { get; set; }

        [Required]
        [MaxLength(MaxLengthClubName)]
        public string Name { get; set; }

        [Required]
        [MaxLength(MaxLengthClubDescription)]
        public string Description { get; set; }

        public string Image { get; set; }

        // DATES
        public DateTime DateEstablished { get; set; }

        // CONTACTS
        public string Email { get; set; }

        // RELATIONS
        public ICollection<ClubStudent> Students { get; set; } = new HashSet<ClubStudent>();

        public ICollection<ClubTeacher> Teachers { get; set; } = new HashSet<ClubTeacher>();

        public bool IsDeleted { get; set; }
        public bool IsUnlisted { get; set; }
    }
}
