using System;

namespace PTSchool.Data.Models
{
    public class Tictactoe
    {
        public string Id { get; set; }

        public DateTime DateTimeCreated { get; set; }

        public DateTime DateTimeFinished { get; set; }

        public bool IsFinished { get; set; }

        public string IdAspNetUser1 { get; set; }

        public string IdAspNetUser2 { get; set; }
    }
}
