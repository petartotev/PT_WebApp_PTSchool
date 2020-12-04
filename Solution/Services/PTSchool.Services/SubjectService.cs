using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Services.Models.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        public const int PageSize = 18;

        private readonly PTSchoolDbContext db;
        private readonly IMapper mapper;

        public SubjectService(PTSchoolDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SubjectLightServiceModel>> GetAllSubjectsLightByPageAsync(int page = 1)
        {
            var subjects = await this.db.Subjects
                .Where(x => x.IsDeleted == false)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                //.Include(x => x.Classes)
                //.Include(x => x.Marks)
                //.Include(x => x.Notes)
                //.Include(x => x.Teachers)
                .ToListAsync();

            var result = this.mapper.Map<IEnumerable<SubjectLightServiceModel>>(subjects);
            return result;
        }

        public async Task<SubjectFullServiceModel> GetSubjectFullByIdAsync(Guid id)
        {
            ValidateSubjectId(id);
            ValidateIfSubjectIsDeleted(id);

            var subject = await this.db.Subjects
                //.Include(x => x.Marks)
                //.Include(x => x.Notes)
                .Include(x => x.Classes)
                .ThenInclude(subjectClass => subjectClass.Class)
                .Include(x => x.Teachers)
                .ThenInclude(subjectTeacher => subjectTeacher.Teacher)
                .FirstOrDefaultAsync(x => x.Id == id);

            var result = this.mapper.Map<SubjectFullServiceModel>(subject);
            return result;
        }

        public int GetPageSize()
        {
            int pageSizeToGet = PageSize;
            return pageSizeToGet;
        }

        public int GetTotalCount()
        {
            return this.db.Subjects.Count();
        }

        public async Task<bool> DeleteSubjectByIdAsync(Guid id)
        {
            var subjectToDelete = await this.db.Subjects
                .FirstOrDefaultAsync(x => x.Id == id);

            if (subjectToDelete is null)
            {
                return false;
            }

            return true;
        }


        private void ValidateSubjectId(Guid id)
        {
            if (!db.Subjects.Any(x => x.Id == id))
            {
                throw new ArgumentException("No Subject with such id.");
            }
        }

        private void ValidateIfSubjectIsUnlisted(Guid id)
        {
            if (db.Subjects.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Subject is unlisted.");
            }
        }

        private void ValidateIfSubjectIsDeleted(Guid id)
        {
            if (db.Subjects.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Subject is deleted.");
            }
        }
    }
}
