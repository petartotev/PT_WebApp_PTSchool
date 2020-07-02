using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Data.Models
{
    public class ClubStudent
    {
        public int ClubId { get; set; }

        public Club Club { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
