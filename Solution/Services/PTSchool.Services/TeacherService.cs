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
                .Include(x => x.Classes)
                .Include(x => x.ClassMastered)
                .Include(x => x.Clubs)
                .Include(x => x.Subjects)
                .Include(x => x.Marks)
                .Include(x => x.Notes)
                .ToListAsync();

            var result = this.mapper.Map<IEnumerable<TeacherLightServiceModel>>(teachers);
            return result;
        }

        public async Task<TeacherLightServiceModel> GetTeacherByIdAsync(Guid id)
        {
            var teacher = await this.db.Teachers
                .Where(x => x.Id == id)
                                .Include(x => x.Classes)
                .Include(x => x.ClassMastered)
                .Include(x => x.Clubs)
                .Include(x => x.Subjects)
                .Include(x => x.Marks)
                .Include(x => x.Notes)
                .FirstOrDefaultAsync();

            var result = this.mapper.Map<TeacherLightServiceModel>(teacher);
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
