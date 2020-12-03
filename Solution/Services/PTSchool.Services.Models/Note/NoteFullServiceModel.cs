using PTSchool.Services.Models.Student;
using PTSchool.Services.Models.Subject;
using PTSchool.Services.Models.Teacher;
using System;

namespace PTSchool.Services.Models.Note
{
    public class NoteFullServiceModel
    {
        public Guid Id { get; set; }

        public string Comment { get; set; }

        public int StatusNote { get; set; }

        public DateTime DateReceived { get; set; }
        public DateTime DateConfirmed { get; set; }

        public StudentLightServiceModel Student { get; set; }

        public SubjectLightServiceModel Subject { get; set; }

        public TeacherLightServiceModel Teacher { get; set; }
    }
}
