using System;

namespace PTSchool.Data.Models
{
    public class ClubStudent
    {
        public Guid ClubId { get; set; }
        public Club Club { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
