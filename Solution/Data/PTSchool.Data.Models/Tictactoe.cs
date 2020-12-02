using System;

namespace PTSchool.Data.Models
{
    public class Tictactoe
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateFinished { get; set; }

        public string IdUser1 { get; set; }
        public string IdUser2 { get; set; }

        public bool IsFinished { get; set; }
    }
}
