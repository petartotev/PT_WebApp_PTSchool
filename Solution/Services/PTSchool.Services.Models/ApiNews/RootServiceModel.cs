using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services.Models.ApiNews
{
    public class RootServiceModel
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<ArticleServiceModel> Articles { get; set; }
    }
}
