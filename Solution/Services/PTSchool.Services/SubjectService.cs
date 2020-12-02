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
        public const int PageSize = 6;

        private readonly PTSchoolDbContext db;
        private readonly IMapper mapper;

        public SubjectService(PTSchoolDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SubjectLightServiceModel>> GetAllSubjectsAsync(int page = 1)
        {
            var subjects = await this.db.Subjects
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

        public async Task<SubjectFullServiceModel> GetSubjectByIdAsync(Guid id)
        {
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
    }
}
