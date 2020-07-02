using AutoMapper;
using MvcSchool.Services.Models.Club;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Services
{
    public interface IClubService
    {
        IEnumerable<ClubProfileFullServiceModel> GetAllClubProfilesFull();

        ClubProfileFullServiceModel GetClubProfileFullById(int id);

        int GetAllClubsCount();

        int GetAllClubsStudentsCount();

        int GetAllClubsTeachersCount();
    }
}
