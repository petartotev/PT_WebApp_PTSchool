using PTSchool.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PTSchool.Data.Models.Validations.StaticValidator.General;

namespace PTSchool.Data.Models
{
    public class Teacher
    {
        // GENERAL
        public Guid Id { get; set; }

        [Required]
        [MaxLength(MaxLengthGeneralName)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(MaxLengthGeneralName)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(MaxLengthGeneralName)]
        public string LastName { get; set; }

        [MaxLength(MaxLengthGeneralDescription)]
        public string Description { get; set; }

        public string Image { get; set; }

        public EnumGender Gender { get; set; }

        public Class ClassMastered { get; set; }

        public bool IsHeadTeacher { get; set; }

        // DATES
        [Required]
        public DateTime DateBirth { get; set; }
        public DateTime DateEmployed { get; set; }
        public DateTime DateCareerStart { get; set; }

        // CONTACTS
        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(MaxLengthGeneralPhone)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(MaxLengthGeneralPhone)]
        public string PhoneEmergency { get; set; }

        // RELATIONS
        public ICollection<TeacherClass> Classes { get; set; } = new HashSet<TeacherClass>();

        public ICollection<ClubTeacher> Clubs { get; set; } = new HashSet<ClubTeacher>();

        public ICollection<Mark> Marks { get; set; } = new HashSet<Mark>();

        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();

        public ICollection<SubjectTeacher> Subjects { get; set; } = new HashSet<SubjectTeacher>();

        public bool IsDeleted { get; set; }
        public bool IsBanned { get; set; }
    }
}
