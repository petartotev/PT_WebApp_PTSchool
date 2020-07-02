using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Services.Models.Mark
{
    public class MarkProfileFullServiceModel
    {
        public int Id { get; set; }

        public int ValueMark { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public DateTime DateReceived { get; set; }

        public DateTime DateConfirmed { get; set; }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public byte[] StudentImageXS { get; set; }

        public int SubjectId { get; set; }
        public byte[] SubjectImageXXS { get; set; }

        public int TeacherId { get; set; }
        public byte[] TeacherImageXXS { get; set; }
    }
}
