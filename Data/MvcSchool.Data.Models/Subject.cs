using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MvcSchool.Data.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
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

        public ICollection<Mark> Marks { get; set; } = new HashSet<Mark>();
        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();

        public ICollection<SubjectTeacher> Teachers { get; set; } = new HashSet<SubjectTeacher>();

        public ICollection<SubjectClass> Classes { get; set; } = new HashSet<SubjectClass>();
    }
}
