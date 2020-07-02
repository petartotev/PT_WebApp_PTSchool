using MvcSchool.Services.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Models.Student
{
    public class AllStudentProfilesFullViewModel
    {
        public IEnumerable<StudentProfileFullServiceModel> AllStudentsFull { get; set; }
                
        public OrderByMethod OrderByMethod { get; set; }

        public AscendingOrDescending AscendingOrDescending { get; set; }
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
