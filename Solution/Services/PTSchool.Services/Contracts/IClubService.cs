using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Club;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Services.Contracts
{
    public interface IClubService : IPageable
    {
        Task<IEnumerable<ClubLightServiceModel>> GetAllClubsLightByPageAsync(int page = 1);

        Task<ClubFullServiceModel> GetClubFullByIdAsync(Guid id);

        Task<bool> DeleteClubByIdAsync(Guid id);

        Task<ClubFullServiceModel> UpdateClubAsync(ClubFullServiceModel club);

        Task<ClubFullServiceModel> CreateClubAsync(ClubFullServiceModel club);

        int GetTotalCountStudentsInClubs();
        int GetTotalCountTeachersInClubs();
    }
}
