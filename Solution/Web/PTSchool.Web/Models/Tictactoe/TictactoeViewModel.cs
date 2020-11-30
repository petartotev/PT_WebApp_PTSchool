using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Models.Tictactoe
{
    public class TictactoeViewModel
    {
        public string Id { get; set; }

        public DateTime DateTimeCreated { get; set; }

        public DateTime DateTimeFinished { get; set; }

        public bool IsFinished { get; set; }

        public string IdAspNetUser1 { get; set; }

        public string IdAspNetUser2 { get; set; }
    }
}
