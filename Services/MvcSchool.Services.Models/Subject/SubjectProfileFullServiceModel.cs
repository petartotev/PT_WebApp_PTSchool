using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Services.Models.Subject
{
    public class SubjectProfileFullServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] ImageM { get; set; }
        public byte[] ImageXS { get; set; }
        public byte[] ImageXXS { get; set; }

        public string Description { get; set; }        

        public IEnumerable<int> TeachersIds { get; set; }
        //public IEnumerable<string> TeachersNames { get; set; }
        public IEnumerable<byte[]> TeachersImagesM { get; set; }
        public IEnumerable<byte[]> TeachersImagesXS { get; set; }
        public IEnumerable<byte[]> TeachersImagesXXS { get; set; }

        public IEnumerable<int> ClassesIds { get; set; }
        //public IEnumerable<string> ClassesNames { get; set; }
        public IEnumerable<byte[]> ClassesImagesM { get; set; }
        public IEnumerable<byte[]> ClassesImagesXS { get; set; }
        public IEnumerable<byte[]> ClassesImagesXXS { get; set; }
    }
}
