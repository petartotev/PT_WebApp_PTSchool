using PTSchool.Services.Models.ApiNews;
using PTSchool.Services.Models.ApiWeather;
using System.Collections.Generic;

namespace PTSchool.Services.Models.Home
{
    public class HomeServiceModel
    {
        public IEnumerable<ArticleServiceModel> News { get; set; }

        public RootWeatherServiceModel RootWeather { get; set; }

        public int CountStudents { get; set; }
        public int CountTeachers { get; set; }
        public int CountParents { get; set; }
        public int CountSubjects { get; set; }
        public int CountClasses { get; set; }
        public int CountClubs { get; set; }
    }
}
