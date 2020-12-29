using PetarTotev.Net.DSA.MyCollections;
using PTSchool.Data;
using PTSchool.Data.Models;
using PTSchool.Data.Models.Enums;
using System;
using System.Linq;

namespace PTSchool.Console.Seeder
{
    public static class PTSchoolDbSeeder
    {
        private static readonly Random random = new Random();

        private static readonly MyList<string> listDescriptionsStudents = new MyList<string>()
        {
            "I love football and sports!",
            "I do believe that war is a bad thing and all wars should stop immediately!",
            "I like to study, read books and be a good child.",
            "I like to dance, swim and go jogging.",
            "I like rock & roll and all extras that come with it.",
            "What about a piece of cake, but a chocolate one, not the ones with the coconut and button on it?",
            "I really like staring at the corners of a room and think about existence and pain.",
            "This is a description of me, but I have nothing to say, so what about you?",
            "I am tall and nice.",
            "Manchester United is my religion.",
            "I am from Greece orginally but my parents brought me here in this strange place...",
            "YOLO!",
            "Goind to parties is my thing. I am a party animal. There is noone like me when it comes to dancing!",
            "I am a cheerleader so my duty is to support brave boys that give everything for the win!",
        };

        private static readonly MyList<string> listFirstNamesMale = new MyList<string>()
            {
                "James",
                "Michael",
                "Robert",
                "John",
                "David",
                "William",
                "Richard",
                "Thomas",
                "Mark",
                "Charles", // 10
                "Steven",
                "Gary",
                "Joseph",
                "Donald",
                "Ronald",
                "Kenneth",
                "Paul",
                "Larry",
                "Daniel",
                "Stephen", // 20
                "Dennis",
                "Timothy",
                "Edward",
                "Jeffrey",
                "George",
                "Gregory",
                "Kevin",
                "Douglas",
                "Terry",
                "Anthony", // 30
                "Jerry",
                "Bruce",
                "Randy",
                "Brian",
                "Frank",
                "Scott",
                "Roger",
                "Raymond",
                "Peter",
                "Patrick", // 40
                "Keith",
                "Lawrence",
                "Wayne",
                "Danny",
                "Alan",
                "Gerald",
                "Ricky",
                "Carl",
                "Christopher",
                "Dale" // 50
            };

        private static readonly MyList<string> listFirstNamesFemale = new MyList<string>()
            {
                "Mary",
                "Linda",
                "Patricia",
                "Susan",
                "Deborah",
                "Barbara",
                "Debra",
                "Karen",
                "Nancy",
                "Donna", // 10
                "Cynthia",
                "Sandra",
                "Pamela",
                "Sharon",
                "Kathleen",
                "Carol",
                "Diane",
                "Brenda",
                "Cheryl",
                "Janet", // 20
                "Elizabeth",
                "Kathy",
                "Margaret",
                "Janice",
                "Carolyn",
                "Denise",
                "Judy",
                "Rebecca",
                "Joyce",
                "Teresa", // 30
                "Christine",
                "Catherine",
                "Shirley",
                "Judith",
                "Betty",
                "Beverly",
                "Lisa",
                "Laura",
                "Theresa",
                "Connie", // 40
                "Ann",
                "Gloria",
                "Julie",
                "Gail",
                "Joan",
                "Paula",
                "Peggy",
                "Cindy",
                "Martha",
                "Bonnie", // 50
            };

        private static readonly MyList<string> listLastNames = new MyList<string>()
            {
                "Smith",
                "Johnson",
                "Williams",
                "Brown",
                "Jones",
                "Garcia",
                "Miller",
                "Davis",
                "Rodriguez",
                "Martinez", // 10
                "Hernandez",
                "Lopez",
                "Gonzalez",
                "Wilson",
                "Anderson",
                "Taylor",
                "Thomas",
                "Moore",
                "Jackson",
                "Martin", // 20
                "Lee",
                "Perez",
                "Thompson",
                "White",
                "Harris",
                "Sanchez",
                "Clark",
                "Ramirez",
                "Lewis",
                "Robinson", // 30
                "Walker",
                "Young",
                "Allen",
                "King",
                "Wright",
                "Scott",
                "Torres",
                "Nguyen",
                "Hill",
                "Flores", // 40
                "Green",
                "Adams",
                "Nelson",
                "Baker",
                "Hall",
                "Rivera",
                "Campbell",
                "Mitchell",
                "Carter",
                "Roberts", // 50
            };

        private static readonly MyList<string> listAddresses = new MyList<string>()
        {
            "Burgas Maria Luisa str. 23",
            "Burgas Kiril i Metodii str. 34",
            "Burgas Tsar Simeon str. 22",
            "Karnobat Vitosha 13",
            "Burgas Izgrev bl. 67",
            "Burgas Izgrev bl. 9",
            "Burgas Tsarigradska str. 11",
            "Pomorie Solna str. 9",
            "Pomorie Odrin str. 3",
            "Sozopol Rodopi str. 5",
            "Karnobat Asen Zlatarov 15",
        };

        private static readonly MyList<string> listOccupations = new MyList<string>()
        {
            "Architect",
            "Engineer",
            "Geodesist",
            "Driver",
            "Doctor",
            "PhD",
            "Agent",
            "Singer",
            "Dancer",
            "CEO",
            "Teacher",
            "Soldier",
            "Politician",
            "Fisherman",
            "Nurse",
            "Technician",
            "Mechanic",
            "Hygienist",
            "Consultant",
            "IT",
            "Musician",
            "Artist",
            "3D Artist"
        };


        public static void SeedMarks(PTSchoolDbContext db)
        {
            System.Console.WriteLine($"SeedMarks started.");

            //8th grade
            for (int student = 1; student <= 120; student++)
            {
                for (int subject = 1; subject <= 16; subject++)
                {
                    var subjectId = db.Subjects.Skip(subject - 1).FirstOrDefault().Id;
                    var studentId = db.Students.Skip(student - 1).FirstOrDefault().Id;

                    if (subject != 1 && subject != 5 && subject != 16)
                    {
                        int mark = random.Next(2, 7);
                        var randomDay = random.Next(0, 366);

                        var numberOfLoops = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).Count();

                        for (int i = 0; i < numberOfLoops; i++)
                        {
                            db.Marks.Add(new Mark
                            {
                                ValueMark = (EnumValueMark)mark,
                                DateReceived = DateTime.UtcNow.AddDays(-randomDay),
                                DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
                                StudentId = studentId,
                                SubjectId = subjectId,
                                TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).Skip(i).FirstOrDefault().TeacherId,
                            });
                            db.SaveChanges();
                            System.Console.Write($"█");
                        }
                    }
                }
            }
            //9th grade
            for (int student = 121; student <= 240; student++)
            {
                for (int subject = 1; subject <= 16; subject++)
                {
                    var subjectId = db.Subjects.Skip(subject - 1).FirstOrDefault().Id;
                    var studentId = db.Students.Skip(student - 1).FirstOrDefault().Id;

                    if (subject != 1 && subject != 11 && subject != 16)
                    {
                        int mark = random.Next(2, 7);
                        var randomDay = random.Next(0, 366);

                        var numberOfLoops = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).Count();

                        for (int i = 0; i < numberOfLoops; i++)
                        {
                            db.Marks.Add(new Mark
                            {
                                ValueMark = (EnumValueMark)mark,
                                DateReceived = DateTime.UtcNow.AddDays(-randomDay),
                                DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
                                StudentId = studentId,
                                SubjectId = subjectId,
                                TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).Skip(i).FirstOrDefault().TeacherId,
                            });
                            db.SaveChanges();
                            System.Console.Write($"█");
                        }
                    }
                }
            }
            //10th grade
            for (int student = 241; student <= 360; student++)
            {
                for (int subject = 1; subject <= 16; subject++)
                {
                    var subjectId = db.Subjects.Skip(subject - 1).FirstOrDefault().Id;
                    var studentId = db.Students.Skip(student - 1).FirstOrDefault().Id;

                    if (subject != 13 && subject != 14 && subject != 11 && subject != 16)
                    {
                        int mark = random.Next(2, 7);
                        var randomDay = random.Next(0, 366);

                        var numberOfLoops = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).Count();

                        for (int i = 0; i < numberOfLoops; i++)
                        {
                            db.Marks.Add(new Mark
                            {
                                ValueMark = (EnumValueMark)mark,
                                DateReceived = DateTime.UtcNow.AddDays(-randomDay),
                                DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
                                StudentId = studentId,
                                SubjectId = subjectId,
                                TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).Skip(i).FirstOrDefault().TeacherId,
                            });
                            db.SaveChanges();
                            System.Console.Write($"█");
                        }
                    }
                }
            }
            //11th grade
            for (int student = 361; student <= 480; student++)
            {
                for (int subject = 1; subject <= 16; subject++)
                {
                    var subjectId = db.Subjects.Skip(subject - 1).FirstOrDefault().Id;
                    var studentId = db.Students.Skip(student - 1).FirstOrDefault().Id;

                    if (subject != 13 && subject != 14 && subject != 11 && subject != 16)
                    {
                        int mark = random.Next(2, 7);
                        var randomDay = random.Next(0, 366);

                        var numberOfLoops = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).Count();

                        for (int i = 0; i < numberOfLoops; i++)
                        {
                            db.Marks.Add(new Mark
                            {
                                ValueMark = (EnumValueMark)mark,
                                DateReceived = DateTime.UtcNow.AddDays(-randomDay),
                                DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
                                StudentId = studentId,
                                SubjectId = subjectId,
                                TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).Skip(i).FirstOrDefault().TeacherId,
                            });
                            db.SaveChanges();
                            System.Console.Write($"█");
                        }
                    }
                }
            }
            //12th grade
            for (int student = 481; student <= 600; student++)
            {
                for (int subject = 1; subject <= 16; subject++)
                {
                    var subjectId = db.Subjects.Skip(subject - 1).FirstOrDefault().Id;
                    var studentId = db.Students.Skip(student - 1).FirstOrDefault().Id;

                    if (subject != 13 && subject != 14 && subject != 11 && subject != 16)
                    {
                        int mark = random.Next(2, 7);
                        var randomDay = random.Next(0, 366);

                        var numberOfLoops = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).Count();

                        for (int i = 0; i < numberOfLoops; i++)
                        {
                            db.Marks.Add(new Mark
                            {
                                ValueMark = (EnumValueMark)mark,
                                DateReceived = DateTime.UtcNow.AddDays(-randomDay),
                                DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
                                StudentId = studentId,
                                SubjectId = subjectId,
                                TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).Skip(i).FirstOrDefault().TeacherId,
                            });
                            db.SaveChanges();
                            System.Console.Write($"█");
                        }
                    }
                }
            }

            System.Console.WriteLine($"\nSeedMarks completed!");
        }

        public static void SeedNotes(PTSchoolDbContext db)
        {
            System.Console.WriteLine($"SeedNotes started.");

            //8th grade
            for (int student = 1; student <= 120; student++)
            {
                for (int subject = 1; subject <= 16; subject++)
                {
                    var subjectId = db.Subjects.Skip(subject - 1).FirstOrDefault().Id;
                    var studentId = db.Students.Skip(student - 1).FirstOrDefault().Id;

                    if (subject != 1 && subject != 5 && subject != 16)
                    {
                        int note = random.Next(1, 7);
                        var randomDay = random.Next(0, 366);
                        db.Notes.Add(new Note
                        {
                            StatusNote = (EnumStatusNote)note,
                            Comment = "Comment on note",
                            DateReceived = DateTime.UtcNow.AddDays(-randomDay),
                            DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
                            StudentId = studentId,
                            SubjectId = subjectId,
                            TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).FirstOrDefault().TeacherId,
                        });
                        db.SaveChanges();
                        System.Console.Write($"█");
                    }
                }
            }
            //9th grade
            for (int student = 121; student <= 240; student++)
            {
                for (int subject = 1; subject <= 16; subject++)
                {
                    var subjectId = db.Subjects.Skip(subject - 1).FirstOrDefault().Id;
                    var studentId = db.Students.Skip(student - 1).FirstOrDefault().Id;

                    if (subject != 1 && subject != 11 && subject != 16)
                    {
                        int note = random.Next(1, 7);
                        var randomDay = random.Next(0, 366);
                        db.Notes.Add(new Note
                        {
                            StatusNote = (EnumStatusNote)note,
                            Comment = "Additional comment on note",
                            DateReceived = DateTime.UtcNow.AddDays(-randomDay),
                            DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
                            StudentId = studentId,
                            SubjectId = subjectId,
                            TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).FirstOrDefault().TeacherId,
                        });
                        db.SaveChanges();
                        System.Console.Write($"█");
                    }
                }
            }
            //10th grade
            for (int student = 241; student <= 360; student++)
            {
                for (int subject = 1; subject <= 16; subject++)
                {
                    var subjectId = db.Subjects.Skip(subject - 1).FirstOrDefault().Id;
                    var studentId = db.Students.Skip(student - 1).FirstOrDefault().Id;

                    if (subject != 13 && subject != 14 && subject != 11 && subject != 16)
                    {
                        int note = random.Next(1, 7);
                        var randomDay = random.Next(0, 366);
                        db.Notes.Add(new Note
                        {
                            StatusNote = (EnumStatusNote)note,
                            Comment = "Additional comment on note",
                            DateReceived = DateTime.UtcNow.AddDays(-randomDay),
                            DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
                            StudentId = studentId,
                            SubjectId = subjectId,
                            TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).FirstOrDefault().TeacherId,
                        });
                        db.SaveChanges();
                        System.Console.Write($"█");
                    }
                }
            }
            //11th grade
            for (int student = 361; student <= 480; student++)
            {
                for (int subject = 1; subject <= 16; subject++)
                {
                    var subjectId = db.Subjects.Skip(subject - 1).FirstOrDefault().Id;
                    var studentId = db.Students.Skip(student - 1).FirstOrDefault().Id;

                    if (subject != 13 && subject != 14 && subject != 11 && subject != 16)
                    {
                        int note = random.Next(1, 7);
                        var randomDay = random.Next(0, 366);
                        db.Notes.Add(new Note
                        {
                            StatusNote = (EnumStatusNote)note,
                            Comment = "Additional comment on note",
                            DateReceived = DateTime.UtcNow.AddDays(-randomDay),
                            DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
                            StudentId = studentId,
                            SubjectId = subjectId,
                            TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).FirstOrDefault().TeacherId,
                        });
                        db.SaveChanges();
                        System.Console.Write($"█");
                    }
                }
            }
            //12th grade
            for (int student = 481; student <= 600; student++)
            {
                for (int subject = 1; subject <= 16; subject++)
                {
                    var subjectId = db.Subjects.Skip(subject - 1).FirstOrDefault().Id;
                    var studentId = db.Students.Skip(student - 1).FirstOrDefault().Id;

                    if (subject != 13 && subject != 14 && subject != 11 && subject != 16)
                    {
                        int note = random.Next(1, 7);
                        var randomDay = random.Next(0, 366);
                        db.Notes.Add(new Note
                        {
                            StatusNote = (EnumStatusNote)note,
                            Comment = "Additional comment on note",
                            DateReceived = DateTime.UtcNow.AddDays(-randomDay),
                            DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
                            StudentId = studentId,
                            SubjectId = subjectId,
                            TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subjectId).FirstOrDefault().TeacherId,
                        });
                        db.SaveChanges();
                        System.Console.Write($"█");
                    }
                }
            }

            System.Console.WriteLine($"\nSeedNotes completed!");
        }

        public static void SeedTeachers(PTSchoolDbContext db, int numberToGenerate)
        {
            System.Console.WriteLine("SeedTeachers started.");

            for (int t = 1; t <= numberToGenerate; t++)
            {
                int gender = random.Next(0, 2);

                string nameFirst = GetRandomFirstName(gender);
                string nameMiddle = GetRandomLastName();
                string nameLast = GetRandomLastName();
                string description = $"{nameFirst} {nameLast} is a teacher with great experience and passion for teaching! For {nameFirst} teaching equals value in life.";
                string image = gender == 0 ? $"/images/teachers/teacher_man_{random.Next(1, 6)}.jpg" : $"/images/teachers/teacher_woman_{random.Next(1, 6)}.jpg";

                string address = GetRandomAddress();
                string phone = GeneratePhoneNumber();
                string phoneEmergency = GeneratePhoneNumber();
                string email = GenerateEmail(nameFirst, nameLast);

                bool isHeadTeacher = false;
                if (t == 1)
                {
                    isHeadTeacher = true;
                }

                DateTime dateBirth = DateTime.UtcNow.AddYears(random.Next(-65, -35)).AddMonths(random.Next(0, 13)).AddDays(random.Next(0, 366));
                DateTime dateEmployed = DateTime.UtcNow.AddYears(random.Next(-5, -2)).AddMonths(random.Next(0, 13)).AddDays(random.Next(0, 366));
                DateTime dateCareerStart = DateTime.UtcNow.AddYears(DateTime.UtcNow.Year - dateBirth.Year - random.Next(20, 35)).AddMonths(random.Next(0, 13)).AddDays(random.Next(0, 366));

                db.Teachers.Add(new Teacher
                {
                    FirstName = nameFirst,
                    MiddleName = nameMiddle,
                    LastName = nameLast,
                    Description = description,
                    Image = image,
                    Gender = (EnumGender)gender,
                    DateBirth = dateBirth,
                    DateEmployed = dateEmployed,
                    DateCareerStart = dateCareerStart,
                    Address = address,
                    Phone = phone,
                    PhoneEmergency = phoneEmergency,
                    Email = email,
                    IsHeadTeacher = isHeadTeacher,

                });
                db.SaveChanges();
                System.Console.Write("█");
            }
            System.Console.WriteLine("\nSeedTeachers completed!");
        }

        public static void SeedClasses(PTSchoolDbContext db)
        {
            System.Console.WriteLine($"SeedClasses started.");

            int numTeacherId = 0;
            for (int i = 8; i <= 12; i++)
            {
                for (int j = 'A'; j <= 'F'; j++)
                {
                    numTeacherId++;
                    db.Classes.Add(new Class
                    {
                        Name = $"{i}" + (char)j,
                        MasterTeacherId = db.Teachers.Skip(numTeacherId).FirstOrDefault().Id,
                        Description = $"Class {i}{(char)j} has passionate students that are eager to learn.",
                        Image = $"/images/classes/logo_class_{i}{(char)j}_M.jpg",

                    });
                    db.SaveChanges();
                    System.Console.Write("█");
                }
            }
            System.Console.WriteLine($"\nSeedClasses completed!");
        }

        public static void SeedStudents(PTSchoolDbContext db)
        {
            System.Console.WriteLine($"SeedStudents started.");

            int numHelper = 0;

            for (int gradeYear = 8; gradeYear <= 12; gradeYear++)
            {
                for (int classLetter = 'A'; classLetter <= 'F'; classLetter++)
                {
                    numHelper++;
                    bool IsSchoolCouncilMember = false;

                    for (int studentNumber = 1; studentNumber <= 20; studentNumber++)
                    {
                        int gender = random.Next(0, 2);

                        string nameFirst = GetRandomFirstName(gender);
                        string nameMiddle = GetRandomLastName();
                        string nameLast = GetRandomLastName();
                        string description = $"My name is {nameFirst} {nameLast}. {GetRandomDescriptionStudent()}";
                        string image = gender == 0 ? $"/images/students/student_boy_{random.Next(1, 6)}.jpg" : $"/images/students/student_girl_{random.Next(1, 6)}.jpg";

                        string address = GetRandomAddress();
                        string phone = GeneratePhoneNumber();
                        string email = GenerateEmail(nameFirst, nameLast);

                        if (studentNumber == 1)
                        {
                            IsSchoolCouncilMember = true;
                        }
                        else
                        {
                            IsSchoolCouncilMember = false;
                        }

                        db.Students.Add(new Student
                        {
                            FirstName = nameFirst,
                            MiddleName = nameMiddle,
                            LastName = nameLast,
                            Description = description,
                            Gender = (EnumGender)gender,
                            DateBirth = DateTime.UtcNow.AddYears(-7 - gradeYear).AddMonths(random.Next(0, 13)).AddDays(random.Next(0, 366)),
                            Status = (EnumStatusStudent)(gradeYear),
                            IsSchoolCouncilMember = IsSchoolCouncilMember,
                            Image = image,
                            Address = address,
                            Email = email,
                            Phone = phone,
                            NumberInClass = studentNumber,
                            ClassId = db.Classes.First(x => x.Name == ($"{gradeYear}" + (char)classLetter)).Id,

                        });
                        db.SaveChanges();
                        System.Console.Write($"█");
                    }
                }
            }
            System.Console.WriteLine($"\nSeedStudents completed!");
        }

        public static void SeedParents(PTSchoolDbContext db)
        {
            System.Console.WriteLine($"SeedParents started.");

            for (int i = 1; i <= 600; i++)
            {
                for (int gender = 0; gender <= 1; gender++)
                {
                    string nameFirst = GetRandomFirstName(gender);
                    string nameMiddle = GetRandomLastName();
                    string nameLast = GetRandomLastName();
                    string description = $"{nameFirst} {nameLast} is a parent that loves his children!";
                    string image = gender == 0 ? $"/images/parents/parent_man_{random.Next(1, 6)}.jpg" : $"/images/parents/parent_woman_{random.Next(1, 6)}.jpg";

                    string address = GetRandomAddress();
                    string phone = GeneratePhoneNumber();
                    string email = GenerateEmail(nameFirst, nameLast);

                    string occupation = GetRandomOccupation();

                    int randomAgeParent = random.Next(32, 54);
                    DateTime dateBirth = DateTime.Now.AddYears(randomAgeParent * (-1)).AddMonths(randomAgeParent).AddDays(randomAgeParent);

                    db.Parents.Add(new Parent
                    {
                        FirstName = nameFirst,
                        MiddleName = nameMiddle,
                        LastName = nameLast,
                        Gender = (EnumGender)gender,
                        Address = address,
                        DateBirth = dateBirth,
                        Email = email,
                        Phone = phone,
                        Occupation = occupation,
                        Description = description,
                        Image = image,
                    });
                    db.SaveChanges();
                    System.Console.Write($"█");
                }
            }
            System.Console.WriteLine("\nSeedParents completed!");
        }

        public static void SeedParentsToStudentsRelation(PTSchoolDbContext db)
        {
            System.Console.WriteLine($"SeedParentsToStudentsRelation started.");
            for (int i = 1; i <= 600; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    var student = db.Students.Skip(i - 1).FirstOrDefault();
                    var parent = db.Parents.Skip((i * 2) - j - 1).FirstOrDefault();

                    db.StudentsParents.Add(new StudentParent
                    {
                        StudentId = student.Id,
                        ParentId = parent.Id,
                    });
                    db.SaveChanges();

                    parent.LastName = student.LastName;
                    db.SaveChanges();

                    System.Console.Write($"█");
                }
            }
            System.Console.WriteLine($"\nSeedParentsToStudentsRelation completed!");
        }

        public static void SeedTeachersToSubjectsRelation(PTSchoolDbContext db)
        {
            System.Console.WriteLine($"SeedTeachersToSubjectsRelation started.");

            var numNext = 0;

            for (int subjectId = 1; subjectId <= 16; subjectId++)
            {
                switch (subjectId)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        for (int i = 1; i <= 3; i++)
                        {
                            numNext++;
                            db.SubjectsTeachers.Add(new SubjectTeacher
                            {
                                SubjectId = db.Subjects.Skip(subjectId - 1).FirstOrDefault().Id,
                                TeacherId = db.Teachers.Skip(numNext).FirstOrDefault().Id,
                            });
                            db.SaveChanges();
                            System.Console.Write($"█");
                        }
                        break;
                    case 11:
                        numNext++;
                        db.SubjectsTeachers.Add(new SubjectTeacher
                        {
                            SubjectId = db.Subjects.Skip(subjectId - 1).FirstOrDefault().Id,
                            TeacherId = db.Teachers.Skip(numNext).FirstOrDefault().Id,
                        });
                        db.SaveChanges();
                        System.Console.Write($"█");
                        break;
                    case 12:
                        for (int i = 1; i <= 3; i++)
                        {
                            numNext++;
                            db.SubjectsTeachers.Add(new SubjectTeacher
                            {
                                SubjectId = db.Subjects.Skip(subjectId - 1).FirstOrDefault().Id,
                                TeacherId = db.Teachers.Skip(numNext).FirstOrDefault().Id,
                            });
                            db.SaveChanges();
                            System.Console.Write($"█");
                        }
                        break;
                    case 13:
                        numNext++;
                        db.SubjectsTeachers.Add(new SubjectTeacher
                        {
                            SubjectId = db.Subjects.Skip(subjectId - 1).FirstOrDefault().Id,
                            TeacherId = db.Teachers.Skip(numNext).FirstOrDefault().Id,
                        });
                        db.SaveChanges();
                        System.Console.Write($"█");
                        break;
                    case 14:
                        numNext++;
                        db.SubjectsTeachers.Add(new SubjectTeacher
                        {
                            SubjectId = db.Subjects.Skip(subjectId - 1).FirstOrDefault().Id,
                            TeacherId = db.Teachers.Skip(numNext).FirstOrDefault().Id,
                        });
                        db.SaveChanges();
                        System.Console.Write($"█");

                        break;
                    case 15:
                        for (int i = 1; i <= 3; i++)
                        {
                            numNext++;
                            db.SubjectsTeachers.Add(new SubjectTeacher
                            {
                                SubjectId = db.Subjects.Skip(subjectId - 1).FirstOrDefault().Id,
                                TeacherId = db.Teachers.Skip(numNext).FirstOrDefault().Id,
                            });
                            db.SaveChanges();
                            System.Console.Write($"█");

                        }
                        break;
                    case 16:
                        numNext++;
                        db.SubjectsTeachers.Add(new SubjectTeacher
                        {
                            SubjectId = db.Subjects.Skip(subjectId - 1).FirstOrDefault().Id,
                            TeacherId = db.Teachers.Skip(numNext).FirstOrDefault().Id,
                        });
                        db.SaveChanges();
                        System.Console.Write($"█");

                        break;
                }
            }
            db.SaveChanges();
            System.Console.Write($"█");

            System.Console.WriteLine($"\nSeedTeachersToSubjectsRelation completed!");

        }

        public static void SeedTeachersToClubsRelation(PTSchoolDbContext db)
        {
            System.Console.WriteLine($"SeedTeachersToClubsRelation started.");

            db.ClubsTeachers.Add(new ClubTeacher
            {
                ClubId = db.Clubs.Skip(0).FirstOrDefault().Id,
                TeacherId = db.Teachers.Skip(random.Next(0, db.Teachers.Count() - 1)).FirstOrDefault().Id,
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.ClubsTeachers.Add(new ClubTeacher
            {
                ClubId = db.Clubs.Skip(1).FirstOrDefault().Id,
                TeacherId = db.Teachers.Skip(random.Next(0, db.Teachers.Count() - 1)).FirstOrDefault().Id,
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.ClubsTeachers.Add(new ClubTeacher
            {
                ClubId = db.Clubs.Skip(2).FirstOrDefault().Id,
                TeacherId = db.Teachers.Skip(random.Next(0, db.Teachers.Count() - 1)).FirstOrDefault().Id,
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.ClubsTeachers.Add(new ClubTeacher
            {
                ClubId = db.Clubs.Skip(3).FirstOrDefault().Id,
                TeacherId = db.Teachers.Skip(random.Next(0, db.Teachers.Count() - 1)).FirstOrDefault().Id,
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.ClubsTeachers.Add(new ClubTeacher
            {
                ClubId = db.Clubs.Skip(4).FirstOrDefault().Id,
                TeacherId = db.Teachers.Skip(random.Next(0, db.Teachers.Count() - 1)).FirstOrDefault().Id,
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.ClubsTeachers.Add(new ClubTeacher
            {
                ClubId = db.Clubs.Skip(5).FirstOrDefault().Id,
                TeacherId = db.Teachers.Skip(random.Next(0, db.Teachers.Count() - 1)).FirstOrDefault().Id,
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.ClubsTeachers.Add(new ClubTeacher
            {
                ClubId = db.Clubs.Skip(6).FirstOrDefault().Id,
                TeacherId = db.Teachers.Skip(random.Next(0, db.Teachers.Count() - 1)).FirstOrDefault().Id,
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.ClubsTeachers.Add(new ClubTeacher
            {
                ClubId = db.Clubs.Skip(7).FirstOrDefault().Id,
                TeacherId = db.Teachers.Skip(random.Next(0, db.Teachers.Count() - 1)).FirstOrDefault().Id,
            });
            db.SaveChanges();
            System.Console.Write($"█");

            System.Console.WriteLine($"\nSeedTeachersToClubsRelation completed!");
        }

        public static void SeedStudentsToClubsRelation(PTSchoolDbContext db)
        {
            System.Console.WriteLine($"SeedStudentsToClubsRelation started.");

            for (int club = 1; club <= 8; club++)
            {
                for (int i = 1; i <= 25; i++)
                {
                    var randomStudentId = db.Students.Skip(random.Next(0, db.Students.Count())).FirstOrDefault().Id;

                    if (!db.ClubsStudents.Any(x => x.StudentId == randomStudentId))
                    {
                        db.ClubsStudents.Add(new ClubStudent
                        {
                            ClubId = db.Clubs.Skip(club - 1).FirstOrDefault().Id,
                            StudentId = randomStudentId,
                        });
                        db.SaveChanges();
                        System.Console.Write($"█");
                    }
                }
            }

            System.Console.WriteLine($"\nSeedStudentsToClubsRelation completed!");
        }

        public static void SeedSubjectsToClasses(PTSchoolDbContext db)
        {
            System.Console.WriteLine($"SeedSubjectsToClasses started.");

            // IT
            for (int classId = 13; classId <= 30; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(0).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // MATH
            for (int classId = 1; classId <= 30; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(1).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // BG
            for (int classId = 1; classId <= 30; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(2).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // ENG
            for (int classId = 1; classId <= 18; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(3).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // DE
            for (int classId = 7; classId <= 30; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(4).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // BIO
            for (int classId = 1; classId <= 30; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(5).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // HIS
            for (int classId = 1; classId <= 30; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(6).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // GEO
            for (int classId = 1; classId <= 30; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(7).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // PHILOSOPHY
            for (int classId = 1; classId <= 24; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(8).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // CHEM
            for (int classId = 1; classId <= 30; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(9).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // WORLD AND HUMAN
            for (int classId = 1; classId <= 6; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(10).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // PHYS
            for (int classId = 1; classId <= 30; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(11).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // MUSIC
            for (int classId = 1; classId <= 6; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(12).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // ART
            for (int classId = 7; classId <= 12; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(13).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // SPORT
            for (int classId = 1; classId <= 30; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(14).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }
            // TRAFFIC
            for (int classId = 25; classId <= 30; classId++)
            {
                db.SubjectsClasses.Add(new SubjectClass
                {
                    SubjectId = db.Subjects.Skip(15).FirstOrDefault().Id,
                    ClassId = db.Classes.Skip(classId - 1).FirstOrDefault().Id
                });
                db.SaveChanges();
                System.Console.Write($"█");
            }

            System.Console.WriteLine($"\nSeedSubjectsToClasses completed!");
        }

        public static void SeedSubjects(PTSchoolDbContext db)
        {
            System.Console.WriteLine($"SeedSubjects started.");

            db.Subjects.Add(new Subject
            {
                Name = "Information Technology",
                Image = $"/images/subjects/logo_subject_IT_M.jpg",
                Description = "Information Technology will show the basics of IT."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "Mathematics",
                Image = $"/images/subjects/logo_subject_math_M.jpg",
                Description = "Subject Mathematics."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "Bulgarian Language and Literature",
                Image = $"/images/subjects/logo_subject_literature_M.jpg",
                Description = "Literature."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "English Language",
                Image = $"/images/subjects/logo_subject_english_M.jpg",
                Description = "Subject English Language."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "German Language",
                Image = $"/images/subjects/logo_subject_deutsch_M.jpg",
                Description = "Subject German Language."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "Biology",
                Image = $"/images/subjects/logo_subject_biology_M.jpg",
                Description = "Subject Biology."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "History",
                Image = $"/images/subjects/logo_subject_history_M.jpg",
                Description = "Subject History."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "Geography",
                Image = $"/images/subjects/logo_subject_geography_M.jpg",
                Description = "Subject Geography."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "Philosophy",
                Image = $"/images/subjects/logo_subject_philosophy_M.jpg",
                Description = "Subject Philosophy."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "Chemistry",
                Image = $"/images/subjects/logo_subject_chemistry_M.jpg",
                Description = "Subject Chemistry."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "World and Person",
                Image = $"/images/subjects/logo_subject_man-world_M.jpg",
                Description = "Subject World and Person."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "Physics",
                Image = $"/images/subjects/logo_subject_physics_M.jpg",
                Description = "Subject Physics."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "Music",
                Image = $"/images/subjects/logo_subject_music_M.jpg",
                Description = "Subject Music."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "Arts",
                Image = $"/images/subjects/logo_subject_art_M.jpg",
                Description = "Subject Arts."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "Sports",
                Image = $"/images/subjects/logo_subject_sport_M.jpg",
                Description = "Subject Sports."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Subjects.Add(new Subject
            {
                Name = "Traffic safety",
                Image = $"/images/subjects/logo_subject_traffic_M.jpg",
                Description = "Subject Traffic safety."
            });
            db.SaveChanges();
            System.Console.Write($"█");

            System.Console.WriteLine($"\nSeedSubjects completed!");
        }

        public static void SeedClubs(PTSchoolDbContext db)
        {
            System.Console.WriteLine("SeedClubs started.");

            db.Clubs.Add(new Club
            {
                Name = "Russian Language",
                Description = "A club for all the students interested in learning Russian language.",
                Image = $"/images/clubs/logo_club_russian_M.jpg",
                DateEstablished = DateTime.Now.AddDays(random.Next(1095, 3650) * (-1)),
                Email = "russianlanguage@club.com",
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Clubs.Add(new Club
            {
                Name = "Chinese Language",
                Description = "A club for all the students interested in learning Chinese language.",
                Image = $"/images/clubs/logo_club_chinese_M.jpg",
                DateEstablished = DateTime.Now.AddDays(random.Next(1095, 3650) * (-1)),
                Email = "chineselanguage@club.com"
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Clubs.Add(new Club
            {
                Name = "Portuguese Language",
                Description = "A club for all the students interested in learning Portuguese language.",
                Image = $"/images/clubs/logo_club_portuguese_M.jpg",
                DateEstablished = DateTime.Now.AddDays(random.Next(1095, 3650) * (-1)),
                Email = "Portuguese@club.com"
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Clubs.Add(new Club
            {
                Name = "Theater",
                Description = "A club for all the students whol love the art of Theater!",
                Image = $"/images/clubs/logo_club_theater_M.jpg",
                DateEstablished = DateTime.Now.AddDays(random.Next(1095, 3650) * (-1)),
                Email = "theater@club.com"
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Clubs.Add(new Club
            {
                Name = "Red Cross",
                Description = "A club for all the students that are ready to volunteer and help the ones in need. A club handled by the Bulgarian Youth Red Cross.",
                Image = $"/images/clubs/logo_club_redcross_M.jpg",
                DateEstablished = DateTime.Now.AddDays(random.Next(1095, 3650) * (-1)),
                Email = "redcross@club.com"
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Clubs.Add(new Club
            {
                Name = "Robotics",
                Description = "A robotics club is a gathering of students who are interested in learning about and working with robots. At school, robotics clubs typically take place after school, in a classroom, and are moderated by a member of the teaching staff or school administration.",
                Image = $"/images/clubs/logo_club_robotics_M.jpg",
                DateEstablished = DateTime.Now.AddDays(random.Next(1095, 3650) * (-1)),
                Email = "robotics@club.com"
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Clubs.Add(new Club
            {
                Name = "Art Club",
                Description = "Most of our art lessons are self-contained, which means you can jump in and start drawing with us today. All you need is something to draw with, some paper, and coloring supplies!",
                Image = $"/images/clubs/logo_club_art_M.jpg",
                DateEstablished = DateTime.Now.AddDays(random.Next(1095, 3650) * (-1)),
                Email = "art@club.com"
            });
            db.SaveChanges();
            System.Console.Write($"█");

            db.Clubs.Add(new Club
            {
                Name = "Comedy Club Sofia",
                Description = "Welcome to Comedy Club – the club where the elite of standup meets the up and coming stars! This is what we do: Club nights at Pod Club – podcast recording with live studio audience Comedy Contest – annual search for next comedy Superstar!!!",
                Image = $"/images/clubs/logo_club_comedy_M.jpg",
                DateEstablished = DateTime.Now.AddDays(random.Next(1095, 3650) * (-1)),
                Email = "comedyclubsofia@club.com"
            });
            db.SaveChanges();
            System.Console.Write($"█");

            System.Console.WriteLine($"\nSeedClubs completed!");
        }

        public static void SeedRoles(PTSchoolDbContext db)
        {
            System.Console.WriteLine("SeedClubs started.");

            db.Roles.Add(new Role
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
            });
            db.SaveChanges();

            db.Roles.Add(new Role
            {
                Name = "Parent",
                NormalizedName = "PARENT",
            });
            db.SaveChanges();

            db.Roles.Add(new Role
            {
                Name = "Student",
                NormalizedName = "STUDENT",
            });
            db.SaveChanges();

            db.Roles.Add(new Role
            {
                Name = "Teacher",
                NormalizedName = "TEACHER",
            });
            db.SaveChanges();

            System.Console.WriteLine($"\nSeedClubs completed!");
        }

        private static string GenerateEmail(string nameFirst, string nameLast)
        {
            return $"{nameFirst.ToLower()}{nameLast.ToLower()}@gmail.com";
        }

        private static string GeneratePhoneNumber()
        {
            return $"+3598{random.Next(7, 10)}{random.Next(6, 10)}{random.Next(100000, 999999)}";
        }

        private static string GetRandomFirstName(int gender)
        {
            if (gender == 0)
            {
                return listFirstNamesMale[random.Next(0, listFirstNamesMale.Count)];
            }

            return listFirstNamesFemale[random.Next(0, listFirstNamesFemale.Count)];
        }

        private static string GetRandomLastName()
        {
            return listLastNames[random.Next(0, listLastNames.Count)];
        }

        private static string GetRandomAddress()
        {
            return listAddresses[random.Next(0, listAddresses.Count)];
        }

        private static string GetRandomOccupation()
        {
            return listOccupations[random.Next(0, listOccupations.Count)];
        }

        private static string GetRandomDescriptionStudent()
        {
            return listDescriptionsStudents[random.Next(0, listDescriptionsStudents.Count())];
        }
    }
}
