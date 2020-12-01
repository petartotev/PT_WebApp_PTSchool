using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PTSchool.Data.Models.DataModelsValidations.Club;

namespace PTSchool.Data.Models
{
    public class Club
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthName)]
        public string Name { get; set; }

        //50x50px
        public byte[] ImageXXS { get; set; }

        //100x100px
        public byte[] ImageXS { get; set; }

        //150x150px
        //public byte[] ImageS { get; set; }

        //300x300px
        public byte[] ImageM { get; set; }

        //600x600px
        //public byte[] ImageL { get; set; }

        [Required]
        [MaxLength(MaxLengthDescription)]
        public string Description { get; set; }

        public string Email { get; set; }

        public DateTime DateOfEstablishment { get; set; }

        public ICollection<ClubStudent> Students { get; set; } = new HashSet<ClubStudent>();

        public ICollection<ClubTeacher> Teachers { get; set; } = new HashSet<ClubTeacher>();
    }
}
