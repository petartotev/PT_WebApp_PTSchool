using PTSchool.Services.Models.ApiNews;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services.Models.Home
{
    public class HomeServiceModel
    {
        public IEnumerable<ArticleServiceModel> News { get; set; }

        public int CountStudents { get; set; }
        public int CountTeachers { get; set; }
        public int CountParents { get; set; }
        public int CountSubjects { get; set; }
        public int CountClasses { get; set; }
        public int CountClubs { get; set; }
    }
}
