using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Data.Models.ApiNews
{
    public class RootNews
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; }
    }
}
