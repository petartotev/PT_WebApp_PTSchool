using PTSchool.Services.Models.Note;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Services
{
    public interface INoteService
    {
        Task<IEnumerable<NoteFullServiceModel>> GetAllNotesByStudentIdAsync(Guid id);

        void AddNoteToStudentByStudentId(NoteFullServiceModel noteToAdd);
    }
}
