using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PTSchool.Data.Models.Validations.StaticValidator.Class;

namespace PTSchool.Data.Models
{
    public class Class
    {
        // GENERAL
        public Guid Id { get; set; }

        [Required]
        [MaxLength(MaxLengthClassName)]
        public string Name { get; set; }

        [MaxLength(MaxLengthClassDescription)]
        public string Description { get; set; }

        public string Image { get; set; }

        // RELATIONS
        public Guid MasterTeacherId { get; set; }
        public Teacher MasterTeacher { get; set; }

        public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        public ICollection<SubjectClass> Subjects { get; set; } = new HashSet<SubjectClass>();

        public ICollection<TeacherClass> Teachers { get; set; } = new HashSet<TeacherClass>();
    }
}
