using PTSchool.Services.Models.Club;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services
{
    public interface IClubService
    {
        IEnumerable<ClubFullServiceModel> GetAllClubProfilesFull();

        ClubFullServiceModel GetClubProfileFullById(int id);

        int GetAllClubsCount();

        int GetAllClubsStudentsCount();

        int GetAllClubsTeachersCount();
    }
}
