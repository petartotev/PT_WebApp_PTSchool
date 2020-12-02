using PTSchool.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PTSchool.Data.Models.Validations.StaticValidator.General;

namespace PTSchool.Data.Models
{
    public class Student
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

        public EnumStatusStudent Status { get; set; }

        public int NumberInClass { get; set; }

        public bool IsSchoolCouncilMember { get; set; }

        // DATES
        [Required]
        public DateTime DateBirth { get; set; }

        // CONTACTS
        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(MaxLengthGeneralPhone)]
        public string Phone { get; set; }

        // RELATIONS
        public Guid ClassId { get; set; }
        public Class Class { get; set; }

        public ICollection<ClubStudent> Clubs { get; set; } = new HashSet<ClubStudent>();

        public ICollection<Mark> Marks { get; set; } = new HashSet<Mark>();

        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();

        public ICollection<StudentParent> Parents { get; set; } = new HashSet<StudentParent>();
    }
}
