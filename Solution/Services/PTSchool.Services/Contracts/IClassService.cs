using PTSchool.Services.Models.Class;
using System.Collections.Generic;

namespace PTSchool.Services
{
    public interface IClassService
    {
        IEnumerable<ClassFullServiceModel> GetAllClasses();

        ClassFullServiceModel GetClassById(int id);
    }
}
