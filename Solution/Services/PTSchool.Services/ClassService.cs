using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Data.Models;
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

            return this.mapper.Map<IEnumerable<ClassLightServiceModel>>(classes);
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

            return this.mapper.Map<ClassFullServiceModel>(classy);
        }

        public async Task<bool> DeleteClassByIdAsync(Guid id)
        {
            ValidateClassId(id);
            ValidateIfClassIsDeleted(id);

            var classToDelete = await this.db.Classes.FindAsync(id);
            classToDelete.IsDeleted = true;
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<ClassFullServiceModel> UpdateClassAsync(ClassFullServiceModel classToUpdate)
        {
            ValidateClassId(classToUpdate.Id);
            ValidateIfClassIsDeleted(classToUpdate.Id);
            ValidateIfInputIsNotNullOrEmpty(classToUpdate.Name);

            var classInDb = await db.Classes.FindAsync(classToUpdate.Id);

            classInDb.Name = classToUpdate.Name;
            classInDb.Description = classToUpdate.Description;
            classInDb.Image = classToUpdate.Image;
            await db.SaveChangesAsync();

            var classInDbUpdated = await db.Classes
                .Include(x => x.MasterTeacher)
                .Include(x => x.Students)
                .Include(x => x.Subjects)
                .Include(x => x.Teachers)
                .FirstOrDefaultAsync(x => x.Id == classToUpdate.Id);

            return this.mapper.Map<ClassFullServiceModel>(classInDbUpdated);
        }

        public async Task<ClassFullServiceModel> CreateClassAsync(ClassFullServiceModel classInput)
        {
            ValidateIfObjectIsNotNull(classInput);
            ValidateIfInputIsNotNullOrEmpty(classInput.Name);

            Class classToCreate = this.mapper.Map<Class>(classInput);

            await SetDefaultImagePathIfImagePathIsNull(classToCreate);
            await SetDefaultDescriptionIfDescriptionIsNull(classToCreate);

            await db.Classes.AddAsync(classToCreate);
            await db.SaveChangesAsync();

            Class classCreated = db.Classes.FirstOrDefault(x => x.Name == classInput.Name && x.Description == classToCreate.Description);
            return this.mapper.Map<ClassFullServiceModel>(classCreated);
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

        private async Task<string> SetDefaultImagePathIfImagePathIsNull(Class classy)
        {
            if (classy.Image is null)
            {
                string imagePathDefault = $"/images/classes/default.jpg";
                classy.Image = imagePathDefault;
                await db.SaveChangesAsync();
            }

            return classy.Image;
        }

        private async Task<string> SetDefaultDescriptionIfDescriptionIsNull(Class classy)
        {
            if (string.IsNullOrEmpty(classy.Description))
            {
                string subjectDefault = $"{classy.Name} is a school class with a number of Students and Teacher that is the master of {classy.Name}.";
                classy.Description = subjectDefault;
                await db.SaveChangesAsync();
            }

            return classy.Description;
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

        private void ValidateIfInputIsNotNullOrEmpty(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Name of a Class cannot be null or empty.");
            }
        }

        private void ValidateIfObjectIsNotNull(ClassFullServiceModel classy)
        {
            if (classy is null)
            {
                throw new ArgumentNullException("The Class cannot be null and needs to have value.");
            }
        }

    }
}
