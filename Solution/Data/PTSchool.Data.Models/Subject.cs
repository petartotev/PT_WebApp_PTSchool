using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PTSchool.Data.Models.Validations.StaticValidator.Subject;

namespace PTSchool.Data.Models
{
    public class Subject
    {
        // GENERAL
        public Guid Id { get; set; }

        [Required]
        [MaxLength(MaxLengthSubjectName)]
        public string Name { get; set; }

        [MaxLength(MaxLengthSubjectDescription)]
        public string Description { get; set; }

        public string Image { get; set; }

        // RELATIONS
        public ICollection<SubjectClass> Classes { get; set; } = new HashSet<SubjectClass>();

        public ICollection<Mark> Marks { get; set; } = new HashSet<Mark>();

        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();

        public ICollection<SubjectTeacher> Teachers { get; set; } = new HashSet<SubjectTeacher>();
    }
}
