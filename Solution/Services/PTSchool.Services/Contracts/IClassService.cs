using PTSchool.Services.Models.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services
{
    public interface IClassService
    {
        IEnumerable<ClassFullServiceModel> GetAllClassProfilesFull();

        ClassFullServiceModel GetClassProfileFullById(int id);
    }
}
