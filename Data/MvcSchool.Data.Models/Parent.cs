using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static MvcSchool.Data.Models.DataModelsValidations.Parent;
using static MvcSchool.Data.Models.DataModelsValidations.General;

namespace MvcSchool.Data.Models
{
    public class Parent
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthName)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(MaxLengthName)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(MaxLengthName)]
        public string LastName { get; set; }

        public EnumGender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(MaxLengthPhone)]
        public string Phone { get; set; }

        [MaxLength(MaxLengthOccupation)]
        public string Occupation { get; set; }

        public ICollection<StudentParent> Students { get; set; } = new HashSet<StudentParent>();

        [MaxLength(MaxLengthAboutMe)]
        public string AboutMe { get; set; }

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
    }
}
