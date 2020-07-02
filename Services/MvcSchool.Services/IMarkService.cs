using MvcSchool.Services.Models.Mark;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Services
{
    public interface IMarkService
    {
        IEnumerable<MarkProfileFullServiceModel> GetAllMarksProfilesFullByStudentId(int id, int page = 1);

        void AddNewMarkProfileToStudentByStudentId(MarkProfileFullServiceModel markToAdd);

        void SignMark(int studentId, int markId);

        int GetTotalMarksByStudentId(int studentId);

        int GetPageCountSizing();

        bool IsAllMarksSignedByParent(int id);
    }
}
