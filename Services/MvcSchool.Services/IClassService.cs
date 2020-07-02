using MvcSchool.Services.Models.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Services
{
    public interface IClassService
    {
        IEnumerable<ClassProfileFullServiceModel> GetAllClassProfilesFull();

        ClassProfileFullServiceModel GetClassProfileFullById(int id);
    }
}
