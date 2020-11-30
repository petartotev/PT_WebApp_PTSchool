using PTSchool.Services.Models.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Models.Note
{
    public class CollectionNotesFullViewModels
    {
        public IEnumerable<NoteFullServiceModel> NoteProfilesFull { get; set; }
    }
}
