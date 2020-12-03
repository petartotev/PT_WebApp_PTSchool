using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Services.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Services.Implementations
{
    public class ClassService : IClassService
    {
        private const int PageSize = 18;

        private readonly PTSchoolDbContext db;
        private readonly IMapper mapper;

        public ClassService(PTSchoolDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ClassLightServiceModel>> GetAllClassesAsync(int page = 1)
        {
            var classes = await this.db.Classes
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                //.Include(x => x.MasterTeacher)
                //.Include(x => x.Students)
                //.Include(x => x.Teachers)
                //.Include(x => x.Subjects)
                .ToListAsync();

            var result = this.mapper.Map<IEnumerable<ClassLightServiceModel>>(classes);
            return result;
        }

        public async Task<ClassFullServiceModel> GetClassByIdAsync(Guid id)
        {
            var classy = await this.db.Classes
                .Include(x => x.MasterTeacher)
                .Include(x => x.Students)
                .Include(x => x.Subjects)
                .Include(x => x.Teachers)
                .FirstOrDefaultAsync(x => x.Id == id);

            var result = this.mapper.Map<ClassFullServiceModel>(classy);
            return result;
        }

        public int GetPageSize()
        {
            int pageSizeToGet = PageSize;
            return pageSizeToGet;
        }

        public int GetTotalCount()
        {
            return this.db.Classes.Count();
        }
    }
}
