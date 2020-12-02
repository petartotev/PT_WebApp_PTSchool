using PTSchool.Web.Models.Abstracts;
using System.Collections.Generic;

namespace PTSchool.Web.Models.Student
{
    public class CollectionStudentsLightViewModels : PageableCollection
    {
        public IEnumerable<StudentLightViewModel> Students { get; set; }
    }

    public enum OrderByMethod
    {
        FirstName = 1,
        LastName = 2,
        Age = 3,
        AverageScore = 4,
        AverageBehavior = 5,
        Class = 6,
        DateOfBirth = 7,
    }

    public enum AscendingOrDescending
    {
        Ascending = 1,
        Descending = 2,
    }
}
