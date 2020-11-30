using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static PTSchool.Data.Models.DataModelsValidations.Student;
using static PTSchool.Data.Models.DataModelsValidations.General;
using System.ComponentModel;

namespace PTSchool.Data.Models
{
    public class Student
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

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(MaxLengthPhone)]
        public string Phone { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int NumberInClass { get; set; }

        public EnumStatusStudent Status { get; set; }

        public bool IsSchoolCouncilMember { get; set; }

        public ICollection<StudentParent> Parents { get; set; } = new HashSet<StudentParent>();

        public ICollection<Mark> Marks { get; set; } = new HashSet<Mark>();

        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();

        public ICollection<ClubStudent> Clubs { get; set; } = new HashSet<ClubStudent>();

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
