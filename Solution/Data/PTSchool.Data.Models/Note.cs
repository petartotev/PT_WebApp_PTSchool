using PTSchool.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using static PTSchool.Data.Models.Validations.StaticValidator.Note;

namespace PTSchool.Data.Models
{
    public class Note
    {
        // GENERAL
        public Guid Id { get; set; }

        [MaxLength(MaxLengthNoteTitle)]
        public string Title { get; set; }

        [MaxLength(MaxLengthNoteComment)]
        public string Comment { get; set; }

        public EnumStatusNote StatusNote { get; set; }

        // DATES
        public DateTime DateReceived { get; set; }
        public DateTime DateConfirmed { get; set; }

        // RELATIONS
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
