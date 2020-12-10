using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Note;
using PTSchool.Web.Models.Note;
using System;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
{
    [Authorize(Roles = "Teacher, Parent, Student")]
    public class NotesController : Controller
    {
        private readonly INoteService noteService;

        public NotesController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        public async Task<IActionResult> AllNotes(Guid id)
        {
            var notesAll = await this.noteService.GetAllNotesByStudentIdAsync(id);

            var model = new CollectionNotesFullViewModels
            {
                //NoteProfilesFull = notesAll
            };

            return this.View(model);
        }

        public IActionResult AddNote(Guid id)
        {
            var model = new NoteFullViewModel
            {
                //StudentId = id
            };
            return this.View(model);
        }

        [HttpPost]
        public IActionResult AddNote(NoteFullViewModel noteProfileToAdd, int id)
        {
            var noteProfileServiceModelToAdd = new NoteFullServiceModel
            {
                //Title = noteProfileToAdd.Title,
                //Comment = noteProfileToAdd.Comment,
                //DateReceived = noteProfileToAdd.DateReceived,
                //StatusNote = (int)noteProfileToAdd.StatusNote,
            };

            this.noteService.AddNoteToStudentByStudentId(noteProfileServiceModelToAdd);

            return this.RedirectToAction("NoteApproved", new { id = id });
        }

        public IActionResult NoteApproved(int id)
        {
            int idToGiveToView = id;
            return this.View(idToGiveToView);
        }
    }
}
