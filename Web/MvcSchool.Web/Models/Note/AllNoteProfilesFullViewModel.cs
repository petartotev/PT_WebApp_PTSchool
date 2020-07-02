using MvcSchool.Services.Models.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Models.Note
{
    public class AllNoteProfilesFullViewModel
    {
        public IEnumerable<NoteProfileFullServiceModel> NoteProfilesFull { get; set; }
    }
}
