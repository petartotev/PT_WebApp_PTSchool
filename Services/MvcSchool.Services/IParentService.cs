using MvcSchool.Services.Models.Parent;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Services
{
    public interface IParentService
    {                     
        IEnumerable<ParentProfileFullServiceModel> GetAllParentProfilesFull(int page = 1);

        ParentProfileFullServiceModel GetParentProfileFullById(int id);

        int Total();
    }
}
