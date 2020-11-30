using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services.Models.Tictactoe
{
    public class TictactoeServiceModel
    {
        public string Id { get; set; }

        public DateTime DateTimeCreated { get; set; }

        public DateTime DateTimeFinished { get; set; }

        public bool IsFinished { get; set; }

        public string IdAspNetUser1 { get; set; }

        public string IdAspNetUser2 { get; set; }
    }
}
