using PTSchool.Services.Models.Club;
using System.Collections.Generic;

namespace PTSchool.Services
{
    public interface IClubService
    {
        IEnumerable<ClubFullServiceModel> GetAllClubs();

        ClubFullServiceModel GetClubById(int id);

        int GetCountAllClubs();

        int GetCountAllStudentsInClubs();

        int GetCountAllTeachersInClubs();
    }
}
