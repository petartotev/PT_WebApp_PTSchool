using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Services.Models.Class
{
    public class ClassProfileFullServiceModel
    {
        public int Id { get; set; }        

        public string Name { get; set; }

        public byte[] ImageM { get; set; }
        public byte[] ImageXS { get; set; }
        public byte[] ImageXXS { get; set; }

        public string Description { get; set; }

        public int MasterTeacherId { get; set; }
        public string MasterTeacherName { get; set; }

        public byte[] MasterTeacherImageM { get; set; }
        public byte[] MasterTeacherImageXS { get; set; }
        public byte[] MasterTeacherImageXXS { get; set; }


        public IEnumerable<int> StudentsIds { get; set; }
        public IEnumerable<string> StudentsNames { get; set; }
        public IEnumerable<string> StudentsEmails { get; set; }
        public IEnumerable<double> StudentsAverageScores { get; set; }

        public IEnumerable<byte[]> StudentsImagesM { get; set; }
        public IEnumerable<byte[]> StudentsImagesXS { get; set; }
        public IEnumerable<byte[]> StudentsImagesXXS { get; set; }



        public int CountStudents { get; set; }
        public int CountGirls { get; set; }
        public int CountBoys { get; set; }        
    }
}
