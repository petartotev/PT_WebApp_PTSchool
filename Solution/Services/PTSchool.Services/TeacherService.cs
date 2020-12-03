using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Services.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSchool.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        public const int PageSize = 18;

        private readonly PTSchoolDbContext db;
        private readonly IMapper mapper;
        public TeacherService(PTSchoolDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TeacherLightServiceModel>> GetAllTeachersAsync(int page = 1)
        {

            var teachers = await this.db.Teachers
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                //.Include(x => x.Classes)
                //.Include(x => x.ClassMastered)
                //.Include(x => x.Clubs)
                //.Include(x => x.Subjects)
                //.Include(x => x.Marks)
                //.Include(x => x.Notes)
                .ToListAsync();

            var result = this.mapper.Map<IEnumerable<TeacherLightServiceModel>>(teachers);
            return result;
        }

        public async Task<TeacherFullServiceModel> GetTeacherByIdAsync(Guid id)
        {
            var teacher = await this.db.Teachers
                .Include(x => x.ClassMastered)
                .Include(x => x.Marks)
                .Include(x => x.Notes)
                .Include(x => x.Clubs)
                .ThenInclude(clubTeacher => clubTeacher.Club)
                .Include(x => x.Subjects)
                .ThenInclude(subjectTeacher => subjectTeacher.Subject)
                .FirstOrDefaultAsync(x => x.Id == id);

            var result = this.mapper.Map<TeacherFullServiceModel>(teacher);
            return result;
        }        

        public int GetPageSize()
        {
            int pageSizeToGet = PageSize;
            return pageSizeToGet;
        }

        public int GetTotalCount()
        {
            return this.db.Teachers.Count();
        }
    }
}
