using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services.Models.Teacher
{
    public class TeacherServiceModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }


        public IEnumerable<int> SubjectsIds { get; set; }
        public IEnumerable<string> SubjectsNames { get; set; }
        public IEnumerable<byte[]> SubjectsImagesM { get; set; }
        public IEnumerable<byte[]> SubjectsImagesXS { get; set; }
        public IEnumerable<byte[]> SubjectsImagesXXS { get; set; }


        public int ClassMasteredId { get; set; }                
        public string ClassMasteredName { get; set; }
        public byte[] ClassMasteredImageM { get; set; }
        public byte[] ClassMasteredImageXS { get; set; }
        public byte[] ClassMasteredImageXXS { get; set; }


        public IEnumerable<int> ClubsMasteredIds { get; set; }  
        public IEnumerable<string> ClubsMasteredNames { get; set; }
        public IEnumerable<byte[]> ClubsMasteredImagesM { get; set; }
        public IEnumerable<byte[]> ClubsMasteredImagesXS { get; set; }
        public IEnumerable<byte[]> ClubsMasteredImagesXXS { get; set; }


        public double AverageMark { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string PhoneEmergency { get; set; }

        public DateTime DateOfEmployment { get; set; }

        public DateTime DateOfCareerStart { get; set; }

        public string AboutMe { get; set; }

        public byte[] ImageM { get; set; }
        public byte[] ImageXS { get; set; }
        public byte[] ImageXXS { get; set; }
    }
}
