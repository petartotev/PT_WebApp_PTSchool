using PTSchool.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PTSchool.Data.Models.Validations.StaticValidator.General;

namespace PTSchool.Data.Models
{
    public class Parent
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

        [MaxLength(MaxLengthGeneralOccupation)]
        public string Occupation { get; set; }

        // DATES
        public DateTime DateBirth { get; set; }

        // CONTACTS
        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(MaxLengthGeneralPhone)]
        public string Phone { get; set; }

        // RELATIONS
        public ICollection<StudentParent> Students { get; set; } = new HashSet<StudentParent>();
    }
}
