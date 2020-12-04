using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Data.Models;
using PTSchool.Services.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private const int PageSize = 18;

        private readonly PTSchoolDbContext db;
        private readonly IMapper mapper;

        public StudentService(PTSchoolDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<StudentLightServiceModel>> GetAllStudentsLightByPageAsync(int page = 1)
        {
            var students = await this.db.Students
                .Where(x => x.IsDeleted == false)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                //.Include(x => x.Class)
                //.Include(x => x.Clubs)
                //.Include(x => x.Marks)
                //.Include(x => x.Notes)
                //.Include(x => x.Parents)
                .ToListAsync();

            var result = this.mapper.Map<IEnumerable<StudentLightServiceModel>>(students);
            return result;
        }

        public async Task<StudentFullServiceModel> GetStudentFullByIdAsync(Guid id)
        {
            ValidateStudentId(id);
            ValidateIfStudentIsDeleted(id);

            var student = await db.Students
                .Include(x => x.Class)
                .Include(x => x.Marks)
                .Include(x => x.Notes)
                .Include(x => x.Parents)
                .ThenInclude(studentParent => studentParent.Parent)
                .Include(x => x.Clubs)
                .ThenInclude(clubStudent => clubStudent.Club)
                .FirstOrDefaultAsync(x => x.Id == id);

            var result = this.mapper.Map<StudentFullServiceModel>(student);
            return result;
        }

        public async Task<IEnumerable<StudentFullServiceModel>> GetAllStudentCouncilMembersAsync()
        {
            var students = await db.Students
                .Include(x => x.Class)
                .Include(x => x.Marks)
                .Include(x => x.Notes)
                .Include(x => x.Parents)
                .ThenInclude(studentParent => studentParent.Parent)
                .Include(x => x.Clubs)
                .ThenInclude(clubStudent => clubStudent.Club)
                .Where(x => x.IsSchoolCouncilMember == true)
                .ToListAsync();

            var result = this.mapper.Map<IEnumerable<StudentFullServiceModel>>(students);
            return result;
        }

        public int GetPageSize()
        {
            int pageSizeToGet = PageSize;
            return pageSizeToGet;
        }

        public int GetTotalCount()
        {
            return this.db.Students.Count();
        }


        private void ValidateStudentId(Guid id)
        {
            if (!db.Students.Any(x => x.Id == id))
            {
                throw new ArgumentException("No Student with such id.");
            }
        }

        private void ValidateIfStudentIsBanned(Guid id)
        {
            if (db.Students.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Student is banned.");
            }
        }

        private void ValidateIfStudentIsDeleted(Guid id)
        {
            if (db.Students.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Student is deleted.");
            }
        }
    }
}
