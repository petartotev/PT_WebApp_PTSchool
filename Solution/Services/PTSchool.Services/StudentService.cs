﻿using AutoMapper;
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

        public async Task<IEnumerable<StudentLightServiceModel>> GetAllStudentsAsync(int page = 1)
        {
            var students = await this.db
                .Students
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Include(x => x.Class)
                .Include(x => x.Clubs)
                .Include(x => x.Marks)
                .Include(x => x.Notes)
                .Include(x => x.Parents)
                .ToListAsync();

            var result = this.mapper.Map<IEnumerable<StudentLightServiceModel>>(students);
            return result;
        }

        public async Task<StudentLightServiceModel> GetStudentByIdAsync(Guid studentId)
        {
            var student = await db.Students
                .Where(x => x.Id == studentId)
                .Include(x => x.Class)
                .Include(x => x.Clubs)
                .Include(x => x.Marks)
                .Include(x => x.Notes)
                .Include(x => x.Parents)
                .FirstOrDefaultAsync();

            var result = this.mapper.Map<StudentLightServiceModel>(student);
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
    }
}
