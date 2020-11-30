using PTSchool.Services.Models.Parent;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services
{
    public interface IParentService
    {                     
        IEnumerable<ParentFullServiceModel> GetAllParentProfilesFull(int page = 1);

        ParentFullServiceModel GetParentProfileFullById(int id);

        int Total();
    }
}
