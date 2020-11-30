using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services.Models.Club
{
    public class ClubFullServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] ImageM { get; set; }
        public byte[] ImageXS { get; set; }
        public byte[] ImageXXS { get; set; }

        public string Description { get; set; }

        public DateTime DateOfEstablishment { get; set; }

        public int CountStudents { get; set; }

        public int CountGirls { get; set; }

        public int CountBoys { get; set; }

        public IEnumerable<int> TeachersIds { get; set; }
        public IEnumerable<byte[]> TeachersImagesM { get; set; }
        public IEnumerable<byte[]> TeachersImagesXS { get; set; }
        public IEnumerable<byte[]> TeachersImagesXXS { get; set; }

        public IEnumerable<int> StudentsIds { get; set; }
        public IEnumerable<byte[]> StudentsImagesM { get; set; }
        public IEnumerable<byte[]> StudentsImagesXS { get; set; }
        public IEnumerable<byte[]> StudentsImagesXXS { get; set; }
    }
}
