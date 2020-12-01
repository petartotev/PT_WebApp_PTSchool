using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PTSchool.Data.Models.DataModelsValidations.Class;

namespace PTSchool.Data.Models
{
    public class Class
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

        public string Description { get; set; }

        public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        public ICollection<TeacherClass> Teachers { get; set; } = new HashSet<TeacherClass>();

        public ICollection<SubjectClass> Subjects { get; set; } = new HashSet<SubjectClass>();

        public int ClassMasterTeacherId { get; set; }

        public Teacher ClassMasterTeacher { get; set; }
    }
}
