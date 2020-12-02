using System;

namespace PTSchool.Data.Models
{
    public class ClubTeacher
    {
        public Guid ClubId { get; set; }
        public Club Club { get; set; }

        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
