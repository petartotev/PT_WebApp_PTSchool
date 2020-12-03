using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Data.Models;
using PTSchool.Data.Models.Enums;
using PTSchool.Services.Models.Note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Services.Implementations
{
    public class NoteService : INoteService
    {
        private readonly PTSchoolDbContext db;
        private readonly IMapper mapper;
        public NoteService(PTSchoolDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddNoteToStudentByStudentId(NoteFullServiceModel noteToAdd)
        {
            this.db.Notes.Add(new Note
            {
                StatusNote = (EnumStatusNote)noteToAdd.StatusNote,
                Comment = noteToAdd.Comment,
                DateReceived = noteToAdd.DateReceived,
                DateConfirmed = noteToAdd.DateConfirmed,
                StudentId = noteToAdd.Student.Id,
                SubjectId = noteToAdd.Subject.Id,
                TeacherId = noteToAdd.Teacher.Id,
            });
            db.SaveChanges();
        }

        public async Task<IEnumerable<NoteFullServiceModel>> GetAllNotesByStudentIdAsync(Guid id)
        {
            var notes = await this.db.Notes
                .Where(x => x.StudentId == id)
                .Include(x => x.Student)
                .Include(x => x.Teacher)
                .Include(x => x.Subject)
                .ToListAsync();

            var result = this.mapper.Map<IEnumerable<NoteFullServiceModel>>(notes);
            return result;
        }
    }
}
