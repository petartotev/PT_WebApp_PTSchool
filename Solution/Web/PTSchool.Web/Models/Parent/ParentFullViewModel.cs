using PTSchool.Web.Models.Abstracts;
using PTSchool.Web.Models.Student;
using System.Collections.Generic;

namespace PTSchool.Web.Models.Parent
{
    public class ParentFullViewModel : PersonEntity
    {
        public string Occupation { get; set; }

        public IEnumerable<StudentLightViewModel> Students { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsBanned { get; set; }
    }
}
