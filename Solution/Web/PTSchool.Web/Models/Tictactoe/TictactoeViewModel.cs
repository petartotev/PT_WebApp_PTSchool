using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Models.Tictactoe
{
    public class TictactoeViewModel
    {
        public string Id { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateFinished { get; set; }

        public bool IsFinished { get; set; }

        public string User1Id { get; set; }

        public string User2Id { get; set; }
    }
}
