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

        public async Task<IEnumerable<ClassLightServiceModel>> GetAllClassesLightByPageAsync(int page = 1)
        {
            var classes = await this.db.Classes
                .Where(x => x.IsDeleted == false)
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

        public async Task<ClassFullServiceModel> GetClassFullByIdAsync(Guid id)
        {
            ValidateClassId(id);
            ValidateIfClassIsDeleted(id);

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


        private void ValidateClassId(Guid id)
        {
            if (!db.Classes.Any(x => x.Id == id))
            {
                throw new ArgumentException("No Class with such id.");
            }
        }

        private void ValidateIfClassIsUnlisted(Guid id)
        {
            if (db.Classes.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Class is unlisted.");
            }
        }

        private void ValidateIfClassIsDeleted(Guid id)
        {
            if (db.Classes.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Class is deleted.");
            }
        }
    }
}
