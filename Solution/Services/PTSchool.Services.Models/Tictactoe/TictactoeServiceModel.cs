using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services.Models.Tictactoe
{
    public class TictactoeServiceModel
    {
        public string Id { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateFinished { get; set; }

        public string IdUser1 { get; set; }
        public string IdUser2 { get; set; }

        public bool IsFinished { get; set; }
    }
}
