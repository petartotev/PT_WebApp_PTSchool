namespace PTSchool.Data.Models.Validations
{
    public static class StaticValidator
    {
        public static class Class
        {
            public const int MaxLengthClassName = 3;
            public const int MaxLengthClassDescription = 500;
        }

        public static class Club
        {
            public const int MaxLengthClubName = 50;
            public const int MaxLengthClubDescription = 500;
        }

        public static class General
        {
            public const int MaxLengthGeneralNameFull = 35;
            public const int MaxLengthGeneralName = 15;
            public const int MaxLengthGeneralPhone = 15;
            public const int MaxLengthGeneralDescription = 500;
            public const int MaxLengthGeneralOccupation = 50;
        }

        public static class Mark
        {
            public const int MaxLengthMarkTitle = 50;
            public const int MaxLengthMarkComment = 200;
        }

        public static class Note
        {
            public const int MaxLengthNoteTitle = 50;
            public const int MaxLengthNoteComment = 500;
        }

        public static class Subject
        {
            public const int MaxLengthSubjectName = 50;
            public const int MaxLengthSubjectDescription = 500;
        }
    }
}
