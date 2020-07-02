using MvcSchool.Services.Models.Note;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Services
{
    public interface INoteService
    {
        IEnumerable<NoteProfileFullServiceModel> GetAllNotesProfilesFullByStudentId(int id);

        void AddNewNoteProfileToStudentByStudentId(NoteProfileFullServiceModel noteToAdd);
    }
}
