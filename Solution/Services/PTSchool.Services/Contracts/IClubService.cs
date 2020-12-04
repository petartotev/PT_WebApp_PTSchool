using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Club;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Services
{
    public interface IClubService : IPageable
    {
        Task<IEnumerable<ClubLightServiceModel>> GetAllClubsLightByPageAsync(int page = 1);

        Task<ClubFullServiceModel> GetClubFullByIdAsync(Guid id);

        int GetTotalCountStudentsInClubs();
        int GetTotalCountTeachersInClubs();
    }
}
