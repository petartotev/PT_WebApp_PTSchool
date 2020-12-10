using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Class;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Services.Contracts
{
    public interface IClassService : IPageable
    {
        Task<IEnumerable<ClassLightServiceModel>> GetAllClassesLightByPageAsync(int page = 1);

        Task<ClassFullServiceModel> GetClassFullByIdAsync(Guid id);

        Task<bool> DeleteClassByIdAsync(Guid Id);

        Task<ClassFullServiceModel> UpdateClassAsync(ClassFullServiceModel classToUpdate);

        Task<ClassFullServiceModel> CreateClassAsync(ClassFullServiceModel classToCreate);
    }
}
