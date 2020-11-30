using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Data.Models
{
    public class ClubTeacher
    {
        public int ClubId { get; set; }

        public Club Club { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}
