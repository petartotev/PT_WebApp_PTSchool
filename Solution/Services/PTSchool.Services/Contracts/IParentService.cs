using PTSchool.Services.Models.Parent;
using System.Collections.Generic;

namespace PTSchool.Services
{
    public interface IParentService
    {
        IEnumerable<ParentFullServiceModel> GetAllParents(int page = 1);

        ParentFullServiceModel GetParentById(int id);

        int GetCountAllParents();
    }
}
