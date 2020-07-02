using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Data.Models
{
    public static class DataModelsValidations
    {
        public static class General
        {
            public const int MaxLengthName = 35;

            public const int MaxLengthPhone = 15;

            public const int MaxLengthAboutMe = 200;
        }

        public static class Class
        {
            public const int MaxLengthName = 3;
        }

        public static class Club
        {
            public const int MaxLengthName = 50;

            public const int MaxLengthDescription = 500;
        }

        public static class Student
        {
        }

        public static class Teacher
        {
        }

        public static class Parent
        {
            public const int MaxLengthOccupation = 20;            
        }

        public static class Mark
        {
            public const int MaxLengthTitle = 50;

            public const int MaxLengthComment = 200;
        }

        public static class Note
        {
            public const int MaxLengthTitle = 50;

            public const int MaxLengthComment = 500;
        }
    }
}
