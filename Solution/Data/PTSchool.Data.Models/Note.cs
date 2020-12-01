using System;
using System.ComponentModel.DataAnnotations;
using static PTSchool.Data.Models.DataModelsValidations.Note;

namespace PTSchool.Data.Models
{
    public class Note
    {
        public int Id { get; set; }

        public EnumStatusNote StatusNote { get; set; }

        [MaxLength(MaxLengthTitle)]
        public string Title { get; set; }

        [MaxLength(MaxLengthComment)]
        public string Comment { get; set; }

        public DateTime DateReceived { get; set; }
        public DateTime DateConfirmed { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
