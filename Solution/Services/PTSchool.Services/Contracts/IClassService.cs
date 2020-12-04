using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Class;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Services
{
    public interface IClassService : IPageable
    {
        Task<IEnumerable<ClassLightServiceModel>> GetAllClassesLightByPageAsync(int page = 1);

        Task<ClassFullServiceModel> GetClassFullByIdAsync(Guid id);
    }
}
