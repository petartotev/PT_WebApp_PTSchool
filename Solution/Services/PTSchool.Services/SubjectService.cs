using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Data.Models;
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

            return this.mapper.Map<IEnumerable<SubjectLightServiceModel>>(subjects);
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

            return this.mapper.Map<SubjectFullServiceModel>(subject);
        }

        public async Task<bool> DeleteSubjectByIdAsync(Guid id)
        {
            ValidateSubjectId(id);
            ValidateIfSubjectIsDeleted(id);

            var subjectToDelete = await this.db.Subjects.FindAsync(id);
            subjectToDelete.IsDeleted = true;
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<SubjectFullServiceModel> UpdateSubjectAsync(SubjectFullServiceModel subject)
        {
            ValidateSubjectId(subject.Id);
            ValidateIfSubjectIsDeleted(subject.Id);
            ValidateIfInputIsNotNullOrEmpty(subject.Name);

            var subjectInDb = await db.Subjects.FindAsync(subject.Id);

            subjectInDb.Name = subject.Name;
            subjectInDb.Description = subject.Description;
            subjectInDb.Image = subject.Image;
            await db.SaveChangesAsync();

            var subjectInDbUpdated = await db.Subjects
                .Include(x => x.Classes)
                .ThenInclude(subjectClass => subjectClass.Class)
                .Include(x => x.Teachers)
                .ThenInclude(subjectTeacher => subjectTeacher.Teacher)
                .FirstOrDefaultAsync(x => x.Id == subject.Id);

            return this.mapper.Map<SubjectFullServiceModel>(subjectInDbUpdated);
        }

        public async Task<SubjectFullServiceModel> CreateSubjectAsync(SubjectFullServiceModel subject)
        {
            ValidateIfObjectIsNotNull(subject);
            ValidateIfInputIsNotNullOrEmpty(subject.Name);

            Subject subjectNew = this.mapper.Map<Subject>(subject);

            await SetDefaultImagePathIfImagePathIsNull(subjectNew);
            await SetDefaultDescriptionIfDescriptionIsNull(subjectNew);

            await db.Subjects.AddAsync(subjectNew);
            await db.SaveChangesAsync();

            Subject subjectCreated = db.Subjects.FirstOrDefault(x => x.Name == subject.Name && x.Description == subjectNew.Description);
            return this.mapper.Map<SubjectFullServiceModel>(subjectCreated);
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


        private async Task<string> SetDefaultImagePathIfImagePathIsNull(Subject subject)
        {
            if (subject.Image is null)
            {
                string imagePathDefault = $"/images/subjects/default.jpg";
                subject.Image = imagePathDefault;
                await db.SaveChangesAsync();
            }

            return subject.Image;
        }

        private async Task<string> SetDefaultDescriptionIfDescriptionIsNull(Subject subject)
        {
            if (string.IsNullOrEmpty(subject.Description))
            {
                string subjectDefault = $"{subject.Name} is a school subject that expands the skills of the students when it comes to this matter.";
                subject.Description = subjectDefault;
                await db.SaveChangesAsync();
            }

            return subject.Description;
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

        private void ValidateIfInputIsNotNullOrEmpty(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Name of a Subject cannot be null or empty.");
            }
        }

        private void ValidateIfObjectIsNotNull(SubjectFullServiceModel subject)
        {
            if (subject is null)
            {
                throw new ArgumentNullException("The Subject cannot be null and needs to have value.");
            }
        }
    }
}
