using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Models.Home
{
    public class HomeViewModel
    {
        public IEnumerable<ArticleViewModel> News { get; set; }

        public WeatherViewModel Weather { get; set; }

        public int CountStudents { get; set; }
        public int CountTeachers { get; set; }
        public int CountParents { get; set; }
        public int CountSubjects { get; set; }
        public int CountClasses { get; set; }
        public int CountClubs { get; set; }
    }
}
