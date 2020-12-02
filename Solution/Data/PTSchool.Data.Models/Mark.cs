using PTSchool.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using static PTSchool.Data.Models.Validations.StaticValidator.Mark;

namespace PTSchool.Data.Models
{
    public class Mark
    {
        // GENERAL
        public Guid Id { get; set; }

        [MaxLength(MaxLengthMarkTitle)]
        public string Title { get; set; }

        [MaxLength(MaxLengthMarkComment)]
        public string Comment { get; set; }

        public EnumValueMark ValueMark { get; set; }

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
