using PTSchool.Services.Models.Mark;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Services.Contracts
{
    public interface IMarkService
    {
        Task<IEnumerable<MarkFullServiceModel>> GetAllMarksByStudentIdAsync(Guid id, int page = 1);

        void AddMarkToStudentByStudentId(MarkFullServiceModel markToAdd);

        void SignMark(Guid studentId, Guid markId);

        int GetTotalMarksByStudentId(Guid studentId);
        int GetPageCountSizing();
        bool IsAllMarksSignedByParent(Guid id);
    }
}
