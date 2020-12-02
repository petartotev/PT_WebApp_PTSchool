using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Services.Implementations
{
    public class ParentService : IParentService
    {
        private const int PageSize = 18;

        private readonly PTSchoolDbContext db;
        private readonly IMapper mapper;

        public ParentService(PTSchoolDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ParentLightServiceModel>> GetAllParentsAsync(int page = 1)
        {
            var parents = await this.db.Parents
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                //.Include(x => x.Students)
                .ToListAsync();

            var result = this.mapper.Map<IEnumerable<ParentLightServiceModel>>(parents);
            return result;
        }

        public async Task<ParentFullServiceModel> GetParentByIdAsync(Guid id)
        {
            var parent = await db.Parents
                .Include(x => x.Students)
                .ThenInclude(studentParent => studentParent.Student)
                .FirstOrDefaultAsync(p => p.Id == id);

            var result = this.mapper.Map<ParentFullServiceModel>(parent);
            return result;
        }

        public int GetPageSize()
        {
            var pageSizeToGet = PageSize;
            return pageSizeToGet;
        }

        public int GetTotalCount()
        {
            return this.db.Parents.Count();
        }
    }
}
