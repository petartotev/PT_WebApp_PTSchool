using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PTSchool.Services.Models.Parent
{
    public class ParentFullServiceModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public string Occupation { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }     

        public string AboutMe { get; set; }

        public byte[] ImageM { get; set; }
        public byte[] ImageXS { get; set; }
        public byte[] ImageXXS { get; set; }

        public IEnumerable<int> ChildrenIds { get; set; }
        public IEnumerable<string> ChildrenNames { get; set; }
        public IEnumerable<byte[]> ChildrenImagesM { get; set; }
        public IEnumerable<byte[]> ChildrenImagesXS { get; set; }
        public IEnumerable<byte[]> ChildrenImagesXXS { get; set; }
    }
}
