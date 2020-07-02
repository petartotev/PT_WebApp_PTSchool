using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MvcSchool.Services.Models.Student
{
    public class StudentProfileFullServiceModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }


        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public byte[] ClassImageM { get; set; }
        public byte[] ClassImageXS { get; set; }
        public byte[] ClassImageXXS { get; set; }


        public int ClassMasterId { get; set; }
        public string ClassMasterName { get; set; }
        public byte[] ClassMasterImageM { get; set; }
        public byte[] ClassMasterImageXS { get; set; }
        public byte[] ClassMasterImageXXS { get; set; }


        public IEnumerable<int> ClubsIds { get; set; }
        public IEnumerable<string> ClubsNames { get; set; }
        public IEnumerable<byte[]> ClubsImagesM { get; set; }
        public IEnumerable<byte[]> ClubsImagesXS { get; set; }
        public IEnumerable<byte[]> ClubsImagesXXS { get; set; }


        public IEnumerable<int> ParentsIds { get; set; }
        public IEnumerable<string> ParentsNames { get; set; }
        public IEnumerable<byte[]> ParentsImagesM { get; set; }
        public IEnumerable<byte[]> ParentsImagesXS { get; set; }
        public IEnumerable<byte[]> ParentsImagesXXS { get; set; }
          

        public double AverageScore { get; set; }
        public double AverageBehavior { get; set; }

        public bool IsSchoolCouncilMember { get; set; }


        public string AboutMe { get; set; }

        public byte[] ImageM { get; set; }
        public byte[] ImageXS { get; set; }
        public byte[] ImageXXS { get; set; }
    }
}
