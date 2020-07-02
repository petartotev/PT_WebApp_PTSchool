using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Services.Models.Note
{
    public class NoteProfileFullServiceModel
    {
        public int Id { get; set; }

        public int StatusNote { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public DateTime DateReceived { get; set; }

        public DateTime DateConfirmed { get; set; }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public byte[] StudentImageM { get; set; }

        public int SubjectId { get; set; }
        public byte[] SubjectImageXXS { get; set; }

        public int TeacherId { get; set; }
        public byte[] TeacherImageXXS { get; set; }
    }
}
