using PTSchool.Data;
using PTSchool.Services.Models.Mark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using PTSchool.Data.Models;

namespace PTSchool.Services.Implementations
{
    public class MarkService : IMarkService
    {
        public int PageSizeCount = 10;

        private readonly MvcSchoolDbContext db;

        public MarkService(MvcSchoolDbContext db)
        {
            this.db = db;
        }

        public void AddNewMarkProfileToStudentByStudentId(MarkFullServiceModel markToAdd)
        {
            this.db.Marks.Add(new Mark
            {
                ValueMark = (EnumValueMark)markToAdd.ValueMark,
                Title = markToAdd.Title,
                Comment = markToAdd.Comment,
                DateReceived = markToAdd.DateReceived,
                DateConfirmed = markToAdd.DateConfirmed,
                StudentId = markToAdd.StudentId,
                SubjectId = markToAdd.SubjectId,
                TeacherId = markToAdd.TeacherId,
            });
            this.db.SaveChanges();
        }

        public IEnumerable<MarkFullServiceModel> GetAllMarksProfilesFullByStudentId(int id, int page = 1)
        {     
            return this.db
                .Marks
                .Where(x => x.StudentId == id)
                .OrderByDescending(x => x.DateReceived)
                .Skip((page - 1) * PageSizeCount)
                .Take(PageSizeCount)
                .Select(x => new MarkFullServiceModel
            {
                Id = x.Id,
                ValueMark = (int)x.ValueMark,
                Title = x.Title,
                Comment = x.Comment,
                StudentId = x.StudentId,
                StudentName = x.Student.FirstName + " " + x.Student.FirstName,
                StudentImageXS = x.Student.ImageM,
                SubjectId = x.SubjectId,
                SubjectImageXXS = x.Subject.ImageXXS,
                TeacherId = x.TeacherId,
                TeacherImageXXS = x.Teacher.ImageXXS,
                DateReceived = x.DateReceived,
                DateConfirmed = x.DateConfirmed,                
            });
        }

        public int GetPageCountSizing()
        {
            return this.PageSizeCount;
        }

        public int GetTotalMarksByStudentId(int studentId)
        {
            return this.db.Marks.Where(x => x.StudentId == studentId).Count();
        }

        public void SignMark(int studentId, int markId)
        {
            this.db.Marks.Where(x => x.StudentId == studentId).Where(x => x.Id == markId).FirstOrDefault().DateConfirmed = DateTime.UtcNow;
            db.SaveChanges();
        }

        public bool IsAllMarksSignedByParent(int id)
        {
            return !this.db.Marks.Where(x => x.StudentId == id).Any(x => x.DateConfirmed == DateTime.MinValue);
        }
    }
}
