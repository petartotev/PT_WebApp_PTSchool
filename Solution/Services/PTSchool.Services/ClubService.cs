using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Services.Models.Club;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Services.Implementations
{
    public class ClubService : IClubService
    {
        private const int PageSize = 18;

        private readonly PTSchoolDbContext db;
        private readonly IMapper mapper;

        public ClubService(PTSchoolDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ClubLightServiceModel>> GetAllClubsLightByPageAsync(int page = 1)
        {
            var clubs = await this.db.Clubs
                .Where(x => x.IsDeleted == false)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                //.Include(x => x.Students)
                //.Include(x => x.Teachers)
                .ToListAsync();

            var result = this.mapper.Map<IEnumerable<ClubLightServiceModel>>(clubs);
            return result;
        }

        public async Task<ClubFullServiceModel> GetClubFullByIdAsync(Guid id)
        {
            ValidateClubId(id);
            ValidateIfClubIsDeleted(id);

            var club = await this.db.Clubs
                .Where(x => x.Id == id)
                .Include(x => x.Students)
                .ThenInclude(clubStudent => clubStudent.Student)
                .Include(x => x.Teachers)
                .ThenInclude(clubTeacher => clubTeacher.Teacher)
                .FirstOrDefaultAsync();

            var result = this.mapper.Map<ClubFullServiceModel>(club);
            return result;
        }

        public async Task<bool> DeleteClubByIdAsync(Guid id)
        {
            ValidateClubId(id);
            ValidateIfClubIsDeleted(id);

            var clubToDelete = await this.db.Clubs.FindAsync(id);
            clubToDelete.IsDeleted = true;
            await db.SaveChangesAsync();

            return true;
        }

        public int GetPageSize()
        {
            int pageSizeToGet = PageSize;
            return pageSizeToGet;
        }

        public int GetTotalCount()
        {
            return this.db.Clubs.Count();
        }

        public int GetTotalCountStudentsInClubs()
        {
            int test = this.db.Clubs.Select(x => x.Students.Count()).ToList().Sum();

            return test;
        }

        public int GetTotalCountTeachersInClubs()
        {
            int test = this.db.Clubs.Select(x => x.Teachers.Count()).ToList().Sum();

            return test;
        }


        private void ValidateClubId(Guid id)
        {
            if (!db.Clubs.Any(x => x.Id == id))
            {
                throw new ArgumentException("No Club with such id.");
            }
        }

        private void ValidateIfClubIsUnlisted(Guid id)
        {
            if (db.Clubs.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Club is unlisted.");
            }
        }

        private void ValidateIfClubIsDeleted(Guid id)
        {
            if (db.Clubs.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Club is deleted.");
            }
        }
    }
}
