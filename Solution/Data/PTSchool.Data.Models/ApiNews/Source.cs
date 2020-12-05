using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Data.Models.ApiNews
{
    public class Source
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; } = new HashSet<Article>();
    }
}
