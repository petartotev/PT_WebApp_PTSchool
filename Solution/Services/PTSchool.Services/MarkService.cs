using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Data.Models;
using PTSchool.Data.Models.Enums;
using PTSchool.Services.Models.Mark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Services.Implementations
{
    public class MarkService : IMarkService
    {
        public int PageSizeCount = 10;

        private readonly PTSchoolDbContext db;
        private readonly IMapper mapper;

        public MarkService(PTSchoolDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddMarkToStudentByStudentId(MarkFullServiceModel markToAdd)
        {
            this.db.Marks.Add(new Mark
            {
                ValueMark = (EnumValueMark)markToAdd.ValueMark,
                Title = markToAdd.Title,
                Comment = markToAdd.Comment,
                DateReceived = markToAdd.DateReceived,
                DateConfirmed = markToAdd.DateConfirmed,
                StudentId = markToAdd.Student.Id,
                SubjectId = markToAdd.Subject.Id,
                TeacherId = markToAdd.Teacher.Id,
            });
            this.db.SaveChanges();
        }

        public async Task<IEnumerable<MarkFullServiceModel>> GetAllMarksByStudentIdAsync(Guid id, int page = 1)
        {
            var marks = await this.db.Marks
                .Where(x => x.StudentId == id)
                .OrderByDescending(x => x.DateReceived)
                .Skip((page - 1) * PageSizeCount)
                .Take(PageSizeCount)
                .Include(x => x.Student)
                .Include(x => x.Teacher)
                .Include(x => x.Subject)
                .ToListAsync();

            var result = this.mapper.Map<IEnumerable<MarkFullServiceModel>>(marks);
            return result;
        }

        public int GetPageCountSizing()
        {
            return this.PageSizeCount;
        }

        public int GetTotalMarksByStudentId(Guid studentId)
        {
            return this.db.Marks.Where(x => x.StudentId == studentId).Count();
        }

        public void SignMark(Guid studentId, Guid markId)
        {
            this.db.Marks.Where(x => x.StudentId == studentId).Where(x => x.Id == markId).FirstOrDefault().DateConfirmed = DateTime.UtcNow;
            db.SaveChanges();
        }

        public bool IsAllMarksSignedByParent(Guid id)
        {
            return !this.db.Marks.Where(x => x.StudentId == id).Any(x => x.DateConfirmed == DateTime.MinValue);
        }
    }
}
