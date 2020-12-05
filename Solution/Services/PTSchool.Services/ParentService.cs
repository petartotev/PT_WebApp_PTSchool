using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Data.Models;
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

        public async Task<IEnumerable<ParentLightServiceModel>> GetAllParentsLightByPageAsync(int page = 1)
        {
            var parents = await this.db.Parents
                .Where(x => x.IsDeleted == false)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                //.Include(x => x.Students)
                .ToListAsync();

            return this.mapper.Map<IEnumerable<ParentLightServiceModel>>(parents);
        }

        public async Task<ParentFullServiceModel> GetParentFullByIdAsync(Guid id)
        {
            ValidateParentId(id);
            ValidateIfParentIsDeleted(id);

            var parent = await db.Parents
                .Include(x => x.Students)
                .ThenInclude(studentParent => studentParent.Student)
                .FirstOrDefaultAsync(p => p.Id == id);

            return this.mapper.Map<ParentFullServiceModel>(parent);
        }

        public async Task<bool> DeleteParentByIdAsync(Guid id)
        {
            ValidateParentId(id);
            ValidateIfParentIsDeleted(id);

            var parentToDelete = await this.db.Parents.FindAsync(id);
            parentToDelete.IsDeleted = true;
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<ParentFullServiceModel> UpdateParentAsync(ParentFullServiceModel parent)
        {
            ValidateParentId(parent.Id);
            ValidateIfParentIsDeleted(parent.Id);
            ValidateIfInputStringIsNotNullOrEmpty(parent.FirstName);
            ValidateIfInputStringIsNotNullOrEmpty(parent.MiddleName);
            ValidateIfInputStringIsNotNullOrEmpty(parent.LastName);

            var parentInDb = await db.Parents.FindAsync(parent.Id);

            parentInDb.FirstName = parent.FirstName;
            parentInDb.MiddleName = parent.MiddleName;
            parentInDb.LastName = parent.LastName;
            parentInDb.Description = parent.Description;
            parentInDb.Image = parent.Image;
            parentInDb.Address = parent.Address;
            parentInDb.Email = parent.Email;
            parentInDb.Phone = parent.Phone;
            await db.SaveChangesAsync();

            var parentInDbUpdated = await db.Parents
                .Include(x => x.Students)
                .ThenInclude(studentParent => studentParent.Student)
                .FirstOrDefaultAsync(p => p.Id == parent.Id);

            return this.mapper.Map<ParentFullServiceModel>(parentInDbUpdated);
        }

        public async Task<ParentFullServiceModel> CreateParentAsync(ParentFullServiceModel parent)
        {
            ValidateIfInputStringIsNotNullOrEmpty(parent.FirstName);
            ValidateIfInputStringIsNotNullOrEmpty(parent.MiddleName);
            ValidateIfInputStringIsNotNullOrEmpty(parent.LastName);
            ValidateIfInputStringIsNotNullOrEmpty(parent.Email);
            ValidateIfInputStringIsNotNullOrEmpty(parent.Phone);
            ValidateIfInputStringIsNotNullOrEmpty(parent.Address);
            ValidateIfDateIsNotNull(parent.DateBirth);

            Parent parentToAddInDb = this.mapper.Map<Parent>(parent);

            await SetDefaultImagePathIfImagePathIsNull(parentToAddInDb);
            await SetDefaultDescriptionIfDescriptionIsNull(parentToAddInDb);

            await this.db.Parents.AddAsync(parentToAddInDb);
            await db.SaveChangesAsync();

            Parent parentAddedInDb = await this.db.Parents.FirstOrDefaultAsync(x => x.FirstName == parent.FirstName && x.MiddleName == parent.MiddleName && x.LastName == parent.LastName);
            return this.mapper.Map<ParentFullServiceModel>(parentAddedInDb);
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


        private async Task<string> SetDefaultImagePathIfImagePathIsNull(Parent parent)
        {
            if (parent.Image is null)
            {
                string imagePathDefault = $"/images/parents/default.jpg";
                parent.Image = imagePathDefault;
                await db.SaveChangesAsync();
            }

            return parent.Image;
        }

        private async Task<string> SetDefaultDescriptionIfDescriptionIsNull(Parent parent)
        {
            if (string.IsNullOrEmpty(parent.Description))
            {
                string subjectDefault = $"{parent.FirstName} is a parent that is part of the PTSchool community. {parent.FirstName}'s child is the thing that makes world worth living!";
                parent.Description = subjectDefault;
                await db.SaveChangesAsync();
            }

            return parent.Description;
        }

        private void ValidateParentId(Guid id)
        {
            if (!db.Parents.Any(x => x.Id == id))
            {
                throw new ArgumentException("No Parent with such id.");
            }
        }

        private void ValidateIfParentIsBanned(Guid id)
        {
            if (db.Parents.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Parent is banned.");
            }
        }

        private void ValidateIfParentIsDeleted(Guid id)
        {
            if (db.Parents.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Parent is deleted.");
            }
        }

        private void ValidateIfInputStringIsNotNullOrEmpty(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Name of a Parent cannot be null or empty.");
            }
        }

        private void ValidateIfDateIsNotNull(DateTime date)
        {
            if (date == default)
            {
                throw new ArgumentException("Date cannot be default.");
            }
        }
    }
}
