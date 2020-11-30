using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static PTSchool.Data.Models.DataModelsValidations.Teacher;
using static PTSchool.Data.Models.DataModelsValidations.General;

namespace PTSchool.Data.Models
{
    public class Teacher
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

        [Required]
        [MaxLength(MaxLengthPhone)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(MaxLengthPhone)]
        public string PhoneEmergency { get; set; }

        public DateTime DateOfEmployment { get; set; }

        public DateTime DateOfCareerStart { get; set; }

        public ICollection<TeacherClass> Classes { get; set; } = new HashSet<TeacherClass>();

        public ICollection<SubjectTeacher> Subjects { get; set; } = new HashSet<SubjectTeacher>();

        public ICollection<ClubTeacher> Clubs { get; set; } = new HashSet<ClubTeacher>();

        public ICollection<Mark> Marks { get; set; } = new HashSet<Mark>();
        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();

        public Class ClassMastered { get; set; }


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
