using PTSchool.Services.Models.Note;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services
{
    public interface INoteService
    {
        IEnumerable<NoteFullServiceModel> GetAllNotesProfilesFullByStudentId(int id);

        void AddNewNoteProfileToStudentByStudentId(NoteFullServiceModel noteToAdd);
    }
}
