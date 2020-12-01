using PTSchool.Services.Models.Mark;
using System.Collections.Generic;

namespace PTSchool.Services
{
    public interface IMarkService
    {
        IEnumerable<MarkFullServiceModel> GetAllMarksByStudentId(int id, int page = 1);

        void AddMarkToStudentByStudentId(MarkFullServiceModel markToAdd);

        void SignMark(int studentId, int markId);

        int GetTotalMarksByStudentId(int studentId);

        int GetPageCountSizing();

        bool IsAllMarksSignedByParent(int id);
    }
}
