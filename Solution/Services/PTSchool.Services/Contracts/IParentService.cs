﻿using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Parent;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Services
{
    public interface IParentService : IPageable
    {
        Task<IEnumerable<ParentLightServiceModel>> GetAllParentsLightByPageAsync(int page = 1);

        Task<ParentFullServiceModel> GetParentFullByIdAsync(Guid id);

        Task<bool> DeleteParentByIdAsync(Guid id);
    }
}
