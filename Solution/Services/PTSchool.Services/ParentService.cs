using PTSchool.Data;
using PTSchool.Services.Models.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PTSchool.Services.Implementations
{
    public class ParentService : IParentService
    {
        private const int ParentsPageSize = 25;

        private readonly MvcSchoolDbContext db;

        public ParentService(MvcSchoolDbContext db)
        {
            this.db = db;
        }
        
        public IEnumerable<ParentFullServiceModel> GetAllParentProfilesFull(int page = 1)
        {
            var allParentProfilesFull = this.db
                .Parents
                .Skip((page - 1) * ParentsPageSize)
                .Take(ParentsPageSize)
                .Select(prnt => new ParentFullServiceModel
            {
                Id = prnt.Id,
                FirstName = prnt.FirstName,
                MiddleName = prnt.MiddleName,
                LastName = prnt.LastName,
                Gender = prnt.Gender.ToString(),
                DateOfBirth = prnt.DateOfBirth,
                Age = (DateTime.Now - prnt.DateOfBirth).Days / 365,
                Occupation = prnt.Occupation,
                Address = prnt.Address,
                Email = prnt.Email,
                Phone = prnt.Phone,
                AboutMe = prnt.AboutMe,
                ImageXS = prnt.ImageXS,
                ChildrenIds = prnt.Students.Select(x => x.Student).Select(z => z.Id).ToList(),
                ChildrenImagesXXS = prnt.Students.Select(x => x.Student).Select(z => z.ImageXXS).ToList(),
            });

            return allParentProfilesFull;
        }

        public ParentFullServiceModel GetParentProfileFullById(int id)
        {
            var parentProfileFullById = db.Parents.Where(x => x.Id == id).Select(prnt => new ParentFullServiceModel
            {
                Id = prnt.Id,
                FirstName = prnt.FirstName,
                MiddleName = prnt.MiddleName,
                LastName = prnt.LastName,
                Gender = prnt.Gender.ToString(),
                DateOfBirth = prnt.DateOfBirth,
                Occupation = prnt.Occupation,
                Address = prnt.Address,
                Email = prnt.Email,
                Phone = prnt.Phone,
                AboutMe = prnt.AboutMe,
                ImageM = prnt.ImageM,
                ChildrenIds = prnt.Students.Select(x => x.Student).Select(z => z.Id).ToList(),
                ChildrenImagesXXS = prnt.Students.Select(x => x.Student).Select(z => z.ImageXXS).ToList(),
            });

            return parentProfileFullById.FirstOrDefault();
        }

        public int Total()
        {
            return this.db.Parents.Count();
        }
    }
}
