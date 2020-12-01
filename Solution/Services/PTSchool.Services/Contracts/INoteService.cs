using PTSchool.Services.Models.Note;
using System.Collections.Generic;

namespace PTSchool.Services
{
    public interface INoteService
    {
        IEnumerable<NoteFullServiceModel> GetAllNotesByStudentId(int id);

        void AddNoteToStudentByStudentId(NoteFullServiceModel noteToAdd);
    }
}
