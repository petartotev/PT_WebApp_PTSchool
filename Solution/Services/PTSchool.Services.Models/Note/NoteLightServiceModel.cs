using System;

namespace PTSchool.Services.Models.Note
{
    public class NoteLightServiceModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int StatusNote { get; set; }

        public DateTime DateReceived { get; set; }
        public DateTime DateConfirmed { get; set; }

        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid TeacherId { get; set; }
    }
}
