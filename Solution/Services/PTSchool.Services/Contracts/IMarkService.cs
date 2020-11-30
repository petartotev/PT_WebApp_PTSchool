using PTSchool.Services.Models.Mark;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services
{
    public interface IMarkService
    {
        IEnumerable<MarkFullServiceModel> GetAllMarksProfilesFullByStudentId(int id, int page = 1);

        void AddNewMarkProfileToStudentByStudentId(MarkFullServiceModel markToAdd);

        void SignMark(int studentId, int markId);

        int GetTotalMarksByStudentId(int studentId);

        int GetPageCountSizing();

        bool IsAllMarksSignedByParent(int id);
    }
}
