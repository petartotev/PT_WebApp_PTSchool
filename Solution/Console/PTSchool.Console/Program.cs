using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using System;

namespace PTSchool.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var db = new MvcSchoolDbContext();

            db.Database.Migrate();

            string pathToAllApplicationImagesJpg = @"D:\D\DOCUMENTS\My Software\PT_Web_App_MvcSchool\mvcschool";

            byte[] byteArrayStudentGirl2M = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_girl_02_M.jpg");
            byte[] byteArrayStudentGirl2XS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_girl_02_XS.jpg");
            byte[] byteArrayStudentGirl2XXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_girl_02_XXS.jpg");
            byte[] byteArrayStudentGirl3M = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_girl_03_M.jpg");
            byte[] byteArrayStudentGirl3XS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_girl_03_XS.jpg");
            byte[] byteArrayStudentGirl3XXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_girl_03_XXS.jpg");

            byte[] byteArrayStudentBoy2M = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_boy_02_M.jpg");
            byte[] byteArrayStudentBoy2XS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_boy_02_XS.jpg");
            byte[] byteArrayStudentBoy2XXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_boy_02_XXS.jpg");
            byte[] byteArrayStudentBoy3M = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_boy_03_M.jpg");
            byte[] byteArrayStudentBoy3XS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_boy_03_XS.jpg");
            byte[] byteArrayStudentBoy3XXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_boy_03_XXS.jpg");

            byte[] byteArrayStudentGirlM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_girl_01_M.jpg");
            byte[] byteArrayStudentGirlXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_girl_01_XS.jpg");
            byte[] byteArrayStudentGirlXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_girl_01_XXS.jpg");
            byte[] byteArrayStudentBoyM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_boy_01_M.jpg");
            byte[] byteArrayStudentBoyXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_boy_01_XS.jpg");
            byte[] byteArrayStudentBoyXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_boy_01_XXS.jpg");
            byte[] byteArrayTeacherManM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_man_teacher_01_M.jpg");
            byte[] byteArrayTeacherManXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_man_teacher_01_XS.jpg");
            byte[] byteArrayTeacherManXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_man_teacher_01_XXS.jpg");
            byte[] byteArrayTeacherWomanM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_woman_teacher_01_M.jpg");
            byte[] byteArrayTeacherWomanXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_woman_teacher_01_XS.jpg");
            byte[] byteArrayTeacherWomanXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_woman_teacher_01_XXS.jpg");
            byte[] byteArrayParentManM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_man_parent_01_M.jpg");
            byte[] byteArrayParentManXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_man_parent_01_XS.jpg");
            byte[] byteArrayParentManXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_man_parent_01_XXS.jpg");
            byte[] byteArrayParentWomanM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_woman_parent_01_M.jpg");
            byte[] byteArrayParentWomanXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_woman_parent_01_XS.jpg");
            byte[] byteArrayParentWomanXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\image_woman_parent_01_XXS.jpg");

            byte[] byteArraySubjectITM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_IT_M.jpg");
            byte[] byteArraySubjectITXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_IT_XS.jpg");
            byte[] byteArraySubjectITXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_IT_XXS.jpg");
            byte[] byteArraySubjectMathM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_math_M.jpg");
            byte[] byteArraySubjectMathXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_math_XS.jpg");
            byte[] byteArraySubjectMathXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_math_XXS.jpg");
            byte[] byteArraySubjectLiteratureM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_literature_M.jpg");
            byte[] byteArraySubjectLiteratureXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_literature_XS.jpg");
            byte[] byteArraySubjectLiteratureXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_literature_XXS.jpg");
            byte[] byteArraySubjectEnglishM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_english_M.jpg");
            byte[] byteArraySubjectEnglishXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_english_XS.jpg");
            byte[] byteArraySubjectEnglishXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_english_XXS.jpg");
            byte[] byteArraySubjectDeutschM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_deutsch_M.jpg");
            byte[] byteArraySubjectDeutschXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_deutsch_XS.jpg");
            byte[] byteArraySubjectDeutschXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_deutsch_XXS.jpg");
            byte[] byteArraySubjectBiologyM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_biology_M.jpg");
            byte[] byteArraySubjectBiologyXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_biology_XS.jpg");
            byte[] byteArraySubjectBiologyXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_biology_XXS.jpg");
            byte[] byteArraySubjectHistoryM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_history_M.jpg");
            byte[] byteArraySubjectHistoryXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_history_XS.jpg");
            byte[] byteArraySubjectHistoryXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_history_XXS.jpg");
            byte[] byteArraySubjectGeographyM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_geography_M.jpg");
            byte[] byteArraySubjectGeographyXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_geography_XS.jpg");
            byte[] byteArraySubjectGeographyXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_geography_XXS.jpg");
            byte[] byteArraySubjectPhilosophyM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_philosophy_M.jpg");
            byte[] byteArraySubjectPhilosophyXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_philosophy_XS.jpg");
            byte[] byteArraySubjectPhilosophyXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_philosophy_XXS.jpg");
            byte[] byteArraySubjectChemistryM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_chemistry_M.jpg");
            byte[] byteArraySubjectChemistryXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_chemistry_XS.jpg");
            byte[] byteArraySubjectChemistryXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_chemistry_XXS.jpg");
            byte[] byteArraySubjectWorldM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_man-world_M.jpg");
            byte[] byteArraySubjectWorldXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_man-world_XS.jpg");
            byte[] byteArraySubjectWorldXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_man-world_XXS.jpg");
            byte[] byteArraySubjectPhysicsM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_physics_M.jpg");
            byte[] byteArraySubjectPhysicsXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_physics_XS.jpg");
            byte[] byteArraySubjectPhysicsXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_physics_XXS.jpg");
            byte[] byteArraySubjectMusicM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_music_M.jpg");
            byte[] byteArraySubjectMusicXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_music_XS.jpg");
            byte[] byteArraySubjectMusicXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_music_XXS.jpg");
            byte[] byteArraySubjectArtsM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_art_M.jpg");
            byte[] byteArraySubjectArtsXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_art_XS.jpg");
            byte[] byteArraySubjectArtsXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_art_XXS.jpg");
            byte[] byteArraySubjectSportsM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_sport_M.jpg");
            byte[] byteArraySubjectSportsXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_sport_XS.jpg");
            byte[] byteArraySubjectSportsXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_sport_XXS.jpg");
            byte[] byteArraySubjectTrafficM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_traffic_M.jpg");
            byte[] byteArraySubjectTrafficXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_traffic_XS.jpg");
            byte[] byteArraySubjectTrafficXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_subject_traffic_XXS.jpg");

            byte[] byteArrayClubTheaterM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_theater_M.jpg");
            byte[] byteArrayClubTheaterXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_theater_XS.jpg");
            byte[] byteArrayClubTheaterXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_theater_XXS.jpg");
            byte[] byteArrayClubRedCrossM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_redcross_M.jpg");
            byte[] byteArrayClubRedCrossXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_redcross_XS.jpg");
            byte[] byteArrayClubRedCrossXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_redcross_XXS.jpg");
            byte[] byteArrayClubRussianM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_russian_M.jpg");
            byte[] byteArrayClubRussianXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_russian_XS.jpg");
            byte[] byteArrayClubRussianXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_russian_XXS.jpg");
            byte[] byteArrayClubPortugueseM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_portuguese_M.jpg");
            byte[] byteArrayClubPortugueseXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_portuguese_XS.jpg");
            byte[] byteArrayClubPortugueseXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_portuguese_XXS.jpg");
            byte[] byteArrayClubChineseM = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_chinese_M.jpg");
            byte[] byteArrayClubChineseXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_chinese_XS.jpg");
            byte[] byteArrayClubChineseXXS = System.IO.File.ReadAllBytes(@$"{pathToAllApplicationImagesJpg}\logo_club_chinese_XXS.jpg");

            ////PT: ADD 45 TEACHERS.
            //var rndmTeacher = new Random();
            //for (int k = 1; k <= 45; k++)
            //{
            //    var randomGender = rndmTeacher.Next(0, 2);

            //    byte[] imageToAttachToTeacherM;
            //    byte[] imageToAttachToTeacherXS;
            //    byte[] imageToAttachToTeacherXXS;

            //    if (randomGender == 0)
            //    {
            //        imageToAttachToTeacherM = byteArrayTeacherManM;
            //        imageToAttachToTeacherXS = byteArrayTeacherManXS;
            //        imageToAttachToTeacherXXS = byteArrayTeacherManXXS;
            //    }
            //    else
            //    {
            //        imageToAttachToTeacherM = byteArrayTeacherWomanM;
            //        imageToAttachToTeacherXS = byteArrayTeacherWomanXS;
            //        imageToAttachToTeacherXXS = byteArrayTeacherWomanXXS;
            //    }

            //    var randomAgeTeacher = rndmTeacher.Next(31, 65);
            //    var randomDateOfEmployment = rndmTeacher.Next(1, 11);

            //    db.Teachers.Add(new Teacher
            //    {
            //        FirstName = $"FirstNameT",
            //        MiddleName = $"MiddleNameT",
            //        LastName = $"LastNameT",
            //        Gender = (EnumGender)randomGender,
            //        DateOfBirth = DateTime.Now.AddYears(randomAgeTeacher * (-1)).AddDays(randomAgeTeacher),
            //        Address = "AddressT",
            //        Email = "EmailT@mvcschool.com",
            //        Phone = "0876543210",
            //        PhoneEmergency = "0123456789",
            //        DateOfEmployment = DateTime.Now.AddYears(randomDateOfEmployment * (-1)).AddDays(randomDateOfEmployment),
            //        DateOfCareerStart = DateTime.Now.AddYears(-(DateTime.Now.Year - DateTime.Now.AddYears(randomAgeTeacher * (-1)).AddDays(randomAgeTeacher).Year - 24)),
            //        AboutMe = "I am a Teacher and I am happy to teach!",
            //        ImageM = imageToAttachToTeacherM,
            //        ImageXS = imageToAttachToTeacherXS,
            //        ImageXXS = imageToAttachToTeacherXXS,
            //    });
            //    db.SaveChanges();
            //}

            //PT: ADD 30 CLASSES FROM 8TH GRADE TO 12TH GRADE + CLASS NAMES FROM 'A' TO 'F'.
            //int numTeacherId = 0;
            //for (int i = 8; i <= 12; i++)
            //{
            //    for (int j = 'A'; j <= 'F'; j++)
            //    {
            //        numTeacherId++;
            //        db.Classes.Add(new Class
            //        {
            //            Name = $"{i}" + (char)j,
            //            ClassMasterTeacherId = numTeacherId,
            //            Description = "Class Description (optional).",
            //            ImageM = System.IO.File.ReadAllBytes(@$"C:\Users\USER\Desktop\mvcschool\logo_class_{i.ToString() + (char)j}_M.jpg"),
            //            ImageXS = System.IO.File.ReadAllBytes(@$"C:\Users\USER\Desktop\mvcschool\logo_class_{i.ToString() + (char)j}_XS.jpg"),
            //            ImageXXS = System.IO.File.ReadAllBytes(@$"C:\Users\USER\Desktop\mvcschool\logo_class_{i.ToString() + (char)j}_XXS.jpg"),
            //        });
            //        db.SaveChanges();
            //    }
            //}

            //PT: ADD STUDENTS TO THE 30 CLASSES.
            //Random rndmStudent = new Random();
            //int numHelper = 0;
            //var isStudentMemberOfCouncil = false;

            //for (int gradeYear = 8; gradeYear <= 12; gradeYear++)
            //{
            //    for (int classLetter = 'a'; classLetter <= 'f'; classLetter++)
            //    {
            //        numHelper++;
            //        for (int studentNumber = 1; studentNumber <= 20; studentNumber++)
            //        {
            //            int dayRandom = rndmStudent.Next(0, 366);

            //            int genderRandom = rndmStudent.Next(0, 2);

            //            byte[] imageToAttachToStudentM;
            //            byte[] imageToAttachToStudentXS;
            //            byte[] imageToAttachToStudentXXS;

            //            if (genderRandom == 0)
            //            {
            //                imageToAttachToStudentM = byteArrayStudentBoyM;
            //                imageToAttachToStudentXS = byteArrayStudentBoyXS;
            //                imageToAttachToStudentXXS = byteArrayStudentBoyXXS;
            //            }
            //            else
            //            {
            //                imageToAttachToStudentM = byteArrayStudentGirlM;
            //                imageToAttachToStudentXS = byteArrayStudentGirlXS;
            //                imageToAttachToStudentXXS = byteArrayStudentGirlXXS;
            //            }

            //            if (studentNumber == 1)
            //            {
            //                isStudentMemberOfCouncil = true;
            //            }
            //            else
            //            {
            //                isStudentMemberOfCouncil = false;
            //            }
            //            db.Students.Add(new Student
            //            {
            //                FirstName = $"FirstName{gradeYear}{(char)classLetter}{studentNumber}",
            //                LastName = $"LastName{gradeYear}{(char)classLetter}{studentNumber}",
            //                MiddleName = $"MiddleName{gradeYear}{(char)classLetter}{studentNumber}",
            //                Gender = (EnumGender)genderRandom,
            //                DateOfBirth = DateTime.Now.AddDays(-((gradeYear + 6.5) * 365) + dayRandom),
            //                Address = $"Address{gradeYear}{(char)classLetter}{studentNumber}",
            //                Email = $"email{gradeYear}{(char)classLetter}{studentNumber}@mvcschool.com",
            //                Phone = $"0888123456",
            //                ClassId = numHelper,
            //                Status = (EnumStatusStudent)gradeYear,
            //                IsSchoolCouncilMember = isStudentMemberOfCouncil,
            //                AboutMe = "I am a Student and I like to play football and go to discos!",
            //                ImageM = imageToAttachToStudentM,
            //                ImageXS = imageToAttachToStudentXS,
            //                ImageXXS = imageToAttachToStudentXXS,
            //            });
            //            db.SaveChanges();
            //        }
            //    }
            //}

            //PT: ADD PARENTS.
            //string parentType = string.Empty;
            //byte[] imageToAttachToParentM;
            //byte[] imageToAttachToParentXS;
            //byte[] imageToAttachToParentXXS;
            //var rndmParent = new Random();
            //for (int i = 1; i <= 600; i++)
            //{
            //    for (int genderIndex = 0; genderIndex <= 1; genderIndex++)
            //    {
            //        var randomAgeParent = rndmParent.Next(25, 55);
            //        if (genderIndex == 0)
            //        {
            //            parentType = "Father";
            //            imageToAttachToParentM = byteArrayParentManM;
            //            imageToAttachToParentXS = byteArrayParentManXS;
            //            imageToAttachToParentXXS = byteArrayParentManXXS;
            //        }
            //        else
            //        {
            //            parentType = "Mother";
            //            imageToAttachToParentM = byteArrayParentWomanM;
            //            imageToAttachToParentXS = byteArrayParentWomanXS;
            //            imageToAttachToParentXXS = byteArrayParentWomanXXS;
            //        }
            //        db.Parents.Add(new Parent
            //        {
            //            FirstName = $"{parentType}FirstNameParent{i}",
            //            MiddleName = $"{parentType}MiddleNameParent{i}",
            //            LastName = $"{parentType}LastNameParent{i}",
            //            Gender = (EnumGender)genderIndex,
            //            Address = $"AddressParent{i}",
            //            DateOfBirth = DateTime.Now.AddYears(randomAgeParent * (-1)).AddDays(randomAgeParent),
            //            Email = $"email{parentType}{i}@reallife.sht",
            //            Phone = $"0888987654",
            //            Occupation = $"Not necessary",
            //            AboutMe = "I am a Parent and I love my Children. They mean the World to me (h)!",
            //            ImageM = imageToAttachToParentM,
            //            ImageXS = imageToAttachToParentXS,
            //            ImageXXS = imageToAttachToParentXXS,
            //        });
            //        db.SaveChanges();
            //    }
            //}

            //PT: ADD STUDENT-PARENT.
            //for (int i = 1; i <= 600; i++)
            //{
            //    for (int j = 0; j <= 1; j++)
            //    {
            //        db.StudentsParents.Add(new StudentParent
            //        {
            //            StudentId = i,
            //            ParentId = (i * 2) - j,
            //        });
            //        db.SaveChanges();
            //    }
            //}

            //PT ADD SUBJECTS.
            //db.Subjects.Add(new Subject
            //{
            //    Name = "Information Technology",
            //    ImageM = byteArraySubjectITM,
            //    ImageXS = byteArraySubjectITXS,
            //    ImageXXS = byteArraySubjectITXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "Mathematics",
            //    ImageM = byteArraySubjectMathM,
            //    ImageXS = byteArraySubjectMathXS,
            //    ImageXXS = byteArraySubjectMathXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "Bulgarian Language and Literature",
            //    ImageM = byteArraySubjectLiteratureM,
            //    ImageXS = byteArraySubjectLiteratureXS,
            //    ImageXXS = byteArraySubjectLiteratureXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "English Language",
            //    ImageM = byteArraySubjectEnglishM,
            //    ImageXS = byteArraySubjectEnglishXS,
            //    ImageXXS = byteArraySubjectEnglishXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "German Language",
            //    ImageM = byteArraySubjectDeutschM,
            //    ImageXS = byteArraySubjectDeutschXS,
            //    ImageXXS = byteArraySubjectDeutschXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "Biology",
            //    ImageM = byteArraySubjectBiologyM,
            //    ImageXS = byteArraySubjectBiologyXS,
            //    ImageXXS = byteArraySubjectBiologyXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "History",
            //    ImageM = byteArraySubjectHistoryM,
            //    ImageXS = byteArraySubjectHistoryXS,
            //    ImageXXS = byteArraySubjectHistoryXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "Geography",
            //    ImageM = byteArraySubjectGeographyM,
            //    ImageXS = byteArraySubjectGeographyXXS,
            //    ImageXXS = byteArraySubjectGeographyXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "Philosophy",
            //    ImageM = byteArraySubjectPhilosophyM,
            //    ImageXS = byteArraySubjectPhilosophyXS,
            //    ImageXXS = byteArraySubjectPhilosophyXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "Chemistry",
            //    ImageM = byteArraySubjectChemistryM,
            //    ImageXS = byteArraySubjectChemistryXS,
            //    ImageXXS = byteArraySubjectChemistryXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "World and Person",
            //    ImageM = byteArraySubjectWorldM,
            //    ImageXS = byteArraySubjectWorldXS,
            //    ImageXXS = byteArraySubjectWorldXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "Physics",
            //    ImageM = byteArraySubjectPhysicsM,
            //    ImageXS = byteArraySubjectPhysicsXS,
            //    ImageXXS = byteArraySubjectPhysicsXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "Music",
            //    ImageM = byteArraySubjectMusicM,
            //    ImageXS = byteArraySubjectMusicXS,
            //    ImageXXS = byteArraySubjectMusicXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "Arts",
            //    ImageM = byteArraySubjectArtsM,
            //    ImageXS = byteArraySubjectArtsXS,
            //    ImageXXS = byteArraySubjectArtsXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "Sports",
            //    ImageM = byteArraySubjectSportsM,
            //    ImageXS = byteArraySubjectSportsXS,
            //    ImageXXS = byteArraySubjectSportsXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();
            //db.Subjects.Add(new Subject
            //{
            //    Name = "Traffic safety",
            //    ImageM = byteArraySubjectTrafficM,
            //    ImageXS = byteArraySubjectTrafficXS,
            //    ImageXXS = byteArraySubjectTrafficXXS,
            //    Description = "Subject Description."
            //});
            //db.SaveChanges();



            //PT: ADD CLUBS.
            //var randomYear = new Random();

            //db.Clubs.Add(new Club
            //{
            //    Name = "Russian Language",
            //    Description = "A club for all the students interested in learning Russian language.",
            //    ImageM = byteArrayClubRussianM,
            //    ImageXS = byteArrayClubRussianXS,
            //    ImageXXS = byteArrayClubRussianXXS,
            //    DateOfEstablishment = DateTime.Now.AddDays(randomYear.Next(1095, 3650) * (-1)),
            //    Email = "Russian@club.com"
            //});
            //db.SaveChanges();
            //db.Clubs.Add(new Club
            //{
            //    Name = "Chinese Language",
            //    Description = "A club for all the students interested in learning Chinese language.",
            //    ImageM = byteArrayClubChineseM,
            //    ImageXS = byteArrayClubChineseXS,
            //    ImageXXS = byteArrayClubChineseXXS,
            //    DateOfEstablishment = DateTime.Now.AddDays(randomYear.Next(1095, 3650) * (-1)),
            //    Email = "Chinese@club.com"
            //});
            //db.SaveChanges();
            //db.Clubs.Add(new Club
            //{
            //    Name = "Portuguese Language",
            //    Description = "A club for all the students interested in learning Portuguese language.",
            //    ImageM = byteArrayClubPortugueseM,
            //    ImageXS = byteArrayClubPortugueseXS,
            //    ImageXXS = byteArrayClubPortugueseXXS,
            //    DateOfEstablishment = DateTime.Now.AddDays(randomYear.Next(1095, 3650) * (-1)),
            //    Email = "Portuguese@club.com"
            //});
            //db.SaveChanges();
            //db.Clubs.Add(new Club
            //{
            //    Name = "Theater",
            //    Description = "A club for all the students whol love the art of Theater!",
            //    ImageM = byteArrayClubTheaterM,
            //    ImageXS = byteArrayClubTheaterXS,
            //    ImageXXS = byteArrayClubTheaterXXS,
            //    DateOfEstablishment = DateTime.Now.AddDays(randomYear.Next(1095, 3650) * (-1)),
            //    Email = "Theater@club.com"
            //});
            //db.SaveChanges();
            //db.Clubs.Add(new Club
            //{
            //    Name = "Red Cross",
            //    Description = "A club for all the students that are ready to volunteer and help the ones in need. A club handled by the Bulgarian Youth Red Cross.",
            //    ImageM = byteArrayClubRedCrossM,
            //    ImageXS = byteArrayClubRedCrossXS,
            //    ImageXXS = byteArrayClubRedCrossXXS,
            //    DateOfEstablishment = DateTime.Now.AddDays(randomYear.Next(1095, 3650) * (-1)),
            //    Email = "RedCross@club.com"
            //});
            //db.SaveChanges();

            //PT: SUBJECTS-TO-TEACHERS
            //var numNext = 0;
            //for (int subjectId = 1; subjectId <= 16; subjectId++)
            //{
            //    switch (subjectId)
            //    {
            //        case 1:
            //        case 2:
            //        case 3:
            //        case 4:
            //        case 5:
            //        case 6:
            //        case 7:
            //        case 8:
            //        case 9:
            //        case 10:
            //            for (int i = 1; i <= 3; i++)
            //            {
            //                numNext++;
            //                db.SubjectsTeachers.Add(new SubjectTeacher
            //                {
            //                    SubjectId = subjectId,
            //                    TeacherId = numNext,
            //                });
            //                db.SaveChanges();
            //            }
            //            break;
            //        case 11:
            //            numNext++;
            //            db.SubjectsTeachers.Add(new SubjectTeacher
            //            {
            //                SubjectId = subjectId,
            //                TeacherId = numNext,
            //            });
            //            db.SaveChanges();
            //            break;
            //        case 12:
            //            for (int i = 1; i <= 3; i++)
            //            {
            //                numNext++;
            //                db.SubjectsTeachers.Add(new SubjectTeacher
            //                {
            //                    SubjectId = subjectId,
            //                    TeacherId = numNext,
            //                });
            //                db.SaveChanges();
            //            }
            //            break;
            //        case 13:
            //            numNext++;
            //            db.SubjectsTeachers.Add(new SubjectTeacher
            //            {
            //                SubjectId = subjectId,
            //                TeacherId = numNext,
            //            });
            //            db.SaveChanges();
            //            break;
            //        case 14:
            //            numNext++;
            //            db.SubjectsTeachers.Add(new SubjectTeacher
            //            {
            //                SubjectId = subjectId,
            //                TeacherId = numNext,
            //            });
            //            db.SaveChanges();
            //            break;
            //        case 15:
            //            for (int i = 1; i <= 3; i++)
            //            {
            //                numNext++;
            //                db.SubjectsTeachers.Add(new SubjectTeacher
            //                {
            //                    SubjectId = subjectId,
            //                    TeacherId = numNext,
            //                });
            //                db.SaveChanges();
            //            }
            //            break;
            //        case 16:
            //            numNext++;
            //            db.SubjectsTeachers.Add(new SubjectTeacher
            //            {
            //                SubjectId = subjectId,
            //                TeacherId = numNext,
            //            });
            //            db.SaveChanges();
            //            break;
            //    }
            //}
            //db.SaveChanges();

            //PT: CLUBS-TO-TEACHERS
            //db.ClubsTeachers.Add(new ClubTeacher
            //{
            //    ClubId = 1,
            //    TeacherId = 41
            //});
            //db.SaveChanges();
            //db.ClubsTeachers.Add(new ClubTeacher
            //{
            //    ClubId = 2,
            //    TeacherId = 42
            //});
            //db.SaveChanges();
            //db.ClubsTeachers.Add(new ClubTeacher
            //{
            //    ClubId = 3,
            //    TeacherId = 43
            //});
            //db.SaveChanges();
            //db.ClubsTeachers.Add(new ClubTeacher
            //{
            //    ClubId = 4,
            //    TeacherId = 44
            //});
            //db.SaveChanges();
            //db.ClubsTeachers.Add(new ClubTeacher
            //{
            //    ClubId = 5,
            //    TeacherId = 45
            //});
            //db.SaveChanges();

            //PT: STUDENTS-TO-CLUBS
            //var rndm3 = new Random();
            //for (int club = 1; club <= 5; club++)
            //{
            //    for (int i = 1; i <= 25; i++)
            //    {
            //        var randomStudent = rndm3.Next(0, 601);

            //        if (!db.ClubsStudents.Any(x => x.StudentId == randomStudent))
            //        {
            //            db.ClubsStudents.Add(new ClubStudent
            //            {
            //                ClubId = club,
            //                StudentId = randomStudent,
            //            });
            //            db.SaveChanges();
            //        }
            //    }
            //}

            //PT: SUBJECTS-TO-CLASSES
            //IT
            //for (int classId = 13; classId <= 30; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 1,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //MATH
            //for (int classId = 1; classId <= 30; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 2,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //BG
            //for (int classId = 1; classId <= 30; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 3,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //ENG
            //for (int classId = 1; classId <= 18; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 4,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //DE
            //for (int classId = 7; classId <= 30; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 5,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //BIO
            //for (int classId = 1; classId <= 30; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 6,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //HIS
            //for (int classId = 1; classId <= 30; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 7,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //GEO
            //for (int classId = 1; classId <= 30; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 8,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //PHILOSOPHY
            //for (int classId = 1; classId <= 24; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 9,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //CHEM
            //for (int classId = 1; classId <= 30; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 10,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //WORLD AND HUMAN
            //for (int classId = 1; classId <= 6; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 11,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //PHYS
            //for (int classId = 1; classId <= 30; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 12,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //MUSIC
            //for (int classId = 1; classId <= 6; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 13,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //ART
            //for (int classId = 7; classId <= 12; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 14,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //SPORT
            //for (int classId = 1; classId <= 30; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 15,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}
            //TRAFFIC
            //for (int classId = 25; classId <= 30; classId++)
            //{
            //    db.SubjectsClasses.Add(new SubjectClass
            //    {
            //        SubjectId = 16,
            //        ClassId = classId
            //    });
            //    db.SaveChanges();
            //}

            //////PT: MARKS!
            //var randomMark = new Random();
            ////8th grade
            //for (int student = 1; student <= 120; student++)
            //{
            //    for (int subject = 1; subject <= 16; subject++)
            //    {
            //        if (subject != 1 && subject != 5 && subject != 16)
            //        {
            //            int mark = randomMark.Next(2, 7);
            //            var randomDay = randomMark.Next(0, 366);

            //            var numberOfLoops = db.SubjectsTeachers.Where(x => x.SubjectId == subject).Count();

            //            for (int i = 0; i < numberOfLoops; i++)
            //            {
            //                db.Marks.Add(new Mark
            //                {
            //                    ValueMark = (EnumValueMark)mark,
            //                    Title = "Title of grade",
            //                    Comment = "Comment on grade",
            //                    DateReceived = DateTime.UtcNow.AddDays(-randomDay),
            //                    DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
            //                    StudentId = student,
            //                    SubjectId = subject,
            //                    TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subject).Skip(i).FirstOrDefault().TeacherId,
            //                });
            //                db.SaveChanges();
            //            }
            //        }
            //    }
            //}
            ////9th grade
            //for (int student = 121; student <= 240; student++)
            //{
            //    for (int subject = 1; subject <= 16; subject++)
            //    {
            //        if (subject != 1 && subject != 11 && subject != 16)
            //        {                       
            //            int mark = randomMark.Next(2, 7);
            //            var randomDay = randomMark.Next(0, 366);

            //            var numberOfLoops = db.SubjectsTeachers.Where(x => x.SubjectId == subject).Count();

            //            for (int i = 0; i < numberOfLoops; i++)
            //            {
            //                db.Marks.Add(new Mark
            //                {
            //                    ValueMark = (EnumValueMark)mark,
            //                    Title = "Title of grade",
            //                    Comment = "Comment on grade",
            //                    DateReceived = DateTime.UtcNow.AddDays(-randomDay),
            //                    DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
            //                    StudentId = student,
            //                    SubjectId = subject,
            //                    TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subject).Skip(i).FirstOrDefault().TeacherId,
            //                });
            //                db.SaveChanges();
            //            }
            //        }
            //    }
            //}
            ////10th grade
            //for (int student = 241; student <= 360; student++)
            //{
            //    for (int subject = 1; subject <= 16; subject++)
            //    {
            //        if (subject != 13 && subject != 14 && subject != 11 && subject != 16)
            //        {                        
            //            int mark = randomMark.Next(2, 7);
            //            var randomDay = randomMark.Next(0, 366);

            //            var numberOfLoops = db.SubjectsTeachers.Where(x => x.SubjectId == subject).Count();

            //            for (int i = 0; i < numberOfLoops; i++)
            //            {
            //                db.Marks.Add(new Mark
            //                {
            //                    ValueMark = (EnumValueMark)mark,
            //                    Title = "Title of grade",
            //                    Comment = "Comment on grade",
            //                    DateReceived = DateTime.UtcNow.AddDays(-randomDay),
            //                    DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
            //                    StudentId = student,
            //                    SubjectId = subject,
            //                    TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subject).Skip(i).FirstOrDefault().TeacherId,
            //                });
            //                db.SaveChanges();
            //            }
            //        }
            //    }
            //}
            ////11th grade
            //for (int student = 361; student <= 480; student++)
            //{
            //    for (int subject = 1; subject <= 16; subject++)
            //    {
            //        if (subject != 13 && subject != 14 && subject != 11 && subject != 16)
            //        {                        
            //            int mark = randomMark.Next(2, 7);
            //            var randomDay = randomMark.Next(0, 366);

            //            var numberOfLoops = db.SubjectsTeachers.Where(x => x.SubjectId == subject).Count();

            //            for (int i = 0; i < numberOfLoops; i++)
            //            {
            //                db.Marks.Add(new Mark
            //                {
            //                    ValueMark = (EnumValueMark)mark,
            //                    Title = "Title of grade",
            //                    Comment = "Comment on grade",
            //                    DateReceived = DateTime.UtcNow.AddDays(-randomDay),
            //                    DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
            //                    StudentId = student,
            //                    SubjectId = subject,
            //                    TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subject).Skip(i).FirstOrDefault().TeacherId,
            //                });
            //                db.SaveChanges();
            //            }
            //        }
            //    }
            //}
            ////12th grade
            //for (int student = 481; student <= 600; student++)
            //{
            //    for (int subject = 1; subject <= 16; subject++)
            //    {
            //        if (subject != 13 && subject != 14 && subject != 11 && subject != 16)
            //        {                        
            //            int mark = randomMark.Next(2, 7);
            //            var randomDay = randomMark.Next(0, 366);

            //            var numberOfLoops = db.SubjectsTeachers.Where(x => x.SubjectId == subject).Count();

            //            for (int i = 0; i < numberOfLoops; i++)
            //            {
            //                db.Marks.Add(new Mark
            //                {
            //                    ValueMark = (EnumValueMark)mark,
            //                    Title = "Title of grade",
            //                    Comment = "Comment on grade",
            //                    DateReceived = DateTime.UtcNow.AddDays(-randomDay),
            //                    DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
            //                    StudentId = student,
            //                    SubjectId = subject,
            //                    TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subject).Skip(i).FirstOrDefault().TeacherId,
            //                });
            //                db.SaveChanges();
            //            }
            //        }
            //    }
            //}

            //////PT: NOTES!
            //var randomNote = new Random();
            ////8th grade
            //for (int student = 1; student <= 120; student++)
            //{
            //    for (int subject = 1; subject <= 16; subject++)
            //    {
            //        if (subject != 1 && subject != 5 && subject != 16)
            //        {
            //            int note = randomNote.Next(1, 7);
            //            var randomDay = randomNote.Next(0, 366);
            //            db.Notes.Add(new Note
            //            {
            //                StatusNote = (EnumStatusNote)note,
            //                Title = "Title of note",
            //                Comment = "Comment on note",
            //                DateReceived = DateTime.UtcNow.AddDays(-randomDay),
            //                DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
            //                StudentId = student,
            //                SubjectId = subject,
            //                TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subject).FirstOrDefault().TeacherId,
            //            });
            //            db.SaveChanges();
            //        }
            //    }
            //}
            ////9th grade
            //for (int student = 121; student <= 240; student++)
            //{
            //    for (int subject = 1; subject <= 16; subject++)
            //    {
            //        if (subject != 1 && subject != 11 && subject != 16)
            //        {
            //            int note = randomNote.Next(1, 7);
            //            var randomDay = randomNote.Next(0, 366);
            //            db.Notes.Add(new Note
            //            {
            //                StatusNote = (EnumStatusNote)note,
            //                Title = "Title of note",
            //                Comment = "Additional comment on note",
            //                DateReceived = DateTime.UtcNow.AddDays(-randomDay),
            //                DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
            //                StudentId = student,
            //                SubjectId = subject,
            //                TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subject).FirstOrDefault().TeacherId,
            //            });
            //            db.SaveChanges();
            //        }
            //    }
            //}
            ////10th grade
            //for (int student = 241; student <= 360; student++)
            //{
            //    for (int subject = 1; subject <= 16; subject++)
            //    {
            //        if (subject != 13 && subject != 14 && subject != 11 && subject != 16)
            //        {
            //            int note = randomNote.Next(1, 7);
            //            var randomDay = randomNote.Next(0, 366);
            //            db.Notes.Add(new Note
            //            {
            //                StatusNote = (EnumStatusNote)note,
            //                Title = "Title of note",
            //                Comment = "Additional comment on note",
            //                DateReceived = DateTime.UtcNow.AddDays(-randomDay),
            //                DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
            //                StudentId = student,
            //                SubjectId = subject,
            //                TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subject).FirstOrDefault().TeacherId,
            //            });
            //            db.SaveChanges();
            //        }
            //    }
            //}
            ////11th grade
            //for (int student = 361; student <= 480; student++)
            //{
            //    for (int subject = 1; subject <= 16; subject++)
            //    {
            //        if (subject != 13 && subject != 14 && subject != 11 && subject != 16)
            //        {
            //            int note = randomNote.Next(1, 7);
            //            var randomDay = randomNote.Next(0, 366);
            //            db.Notes.Add(new Note
            //            {
            //                StatusNote = (EnumStatusNote)note,
            //                Title = "Title of note",
            //                Comment = "Additional comment on note",
            //                DateReceived = DateTime.UtcNow.AddDays(-randomDay),
            //                DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
            //                StudentId = student,
            //                SubjectId = subject,
            //                TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subject).FirstOrDefault().TeacherId,
            //            });
            //            db.SaveChanges();
            //        }
            //    }
            //}
            ////12th grade
            //for (int student = 481; student <= 600; student++)
            //{
            //    for (int subject = 1; subject <= 16; subject++)
            //    {
            //        if (subject != 13 && subject != 14 && subject != 11 && subject != 16)
            //        {
            //            int note = randomNote.Next(1, 7);
            //            var randomDay = randomNote.Next(0, 366);
            //            db.Notes.Add(new Note
            //            {
            //                StatusNote = (EnumStatusNote)note,
            //                Title = "Title of note",
            //                Comment = "Additional comment on note",
            //                DateReceived = DateTime.UtcNow.AddDays(-randomDay),
            //                DateConfirmed = DateTime.UtcNow.AddDays(-randomDay + 2),
            //                StudentId = student,
            //                SubjectId = subject,
            //                TeacherId = db.SubjectsTeachers.Where(x => x.SubjectId == subject).FirstOrDefault().TeacherId,
            //            });
            //            db.SaveChanges();
            //        }
            //    }
            //}

            ////PT: ADD SOME MORE RANDOM IMAGES TO STUDENTS GIRLS AND BOYS
            ////PT: GIRLS 2 AND GIRLS 3
            //for (int i = 1; i <= 200; i++)
            //{
            //    var randomGirl = new Random();
            //    var randomGirlNext = randomGirl.Next(1, 601);

            //    if ((int)db.Students.Where(x => x.Id == randomGirlNext).First().Gender == 1)
            //    {
            //        db.Students.Where(y => y.Id == randomGirlNext).First().ImageM = byteArrayStudentGirl3M;
            //        db.Students.Where(y => y.Id == randomGirlNext).First().ImageXS = byteArrayStudentGirl3XS;
            //        db.Students.Where(y => y.Id == randomGirlNext).First().ImageXXS = byteArrayStudentGirl3XXS;

            //        db.SaveChanges();
            //    }
            //}
            //for (int i = 1; i <= 200; i++)
            //{
            //    var randomGirl = new Random();
            //    var randomGirlNext = randomGirl.Next(1, 601);

            //    if ((int)db.Students.Where(x => x.Id == randomGirlNext).First().Gender == 1)
            //    {
            //        db.Students.Where(y => y.Id == randomGirlNext).First().ImageM = byteArrayStudentGirl2M;
            //        db.Students.Where(y => y.Id == randomGirlNext).First().ImageXS = byteArrayStudentGirl2XS;
            //        db.Students.Where(y => y.Id == randomGirlNext).First().ImageXXS = byteArrayStudentGirl2XXS;

            //        db.SaveChanges();
            //    }
            //}
            ////PT: BOYS 2 AND BOYS 3
            //for (int i = 1; i <= 200; i++)
            //{
            //    var randomBoy = new Random();
            //    var randomBoyNext = randomBoy.Next(1, 601);

            //    if ((int)db.Students.Where(x => x.Id == randomBoyNext).First().Gender == 0)
            //    {
            //        db.Students.Where(y => y.Id == randomBoyNext).First().ImageM = byteArrayStudentBoy3M;
            //        db.Students.Where(y => y.Id == randomBoyNext).First().ImageXS = byteArrayStudentBoy3XS;
            //        db.Students.Where(y => y.Id == randomBoyNext).First().ImageXXS = byteArrayStudentBoy3XXS;

            //        db.SaveChanges();
            //    }
            //}
            //for (int i = 1; i <= 200; i++)
            //{
            //    var randomBoy = new Random();
            //    var randomBoyNext = randomBoy.Next(1, 601);

            //    if ((int)db.Students.Where(x => x.Id == randomBoyNext).First().Gender == 0)
            //    {
            //        db.Students.Where(y => y.Id == randomBoyNext).First().ImageM = byteArrayStudentBoy2M;
            //        db.Students.Where(y => y.Id == randomBoyNext).First().ImageXS = byteArrayStudentBoy2XS;
            //        db.Students.Where(y => y.Id == randomBoyNext).First().ImageXXS = byteArrayStudentBoy2XXS;

            //        db.SaveChanges();
            //    }
            //}

            //db.Students.FirstOrDefault().AboutMe = $"I'm a Student! I like to go to the disco, play the guitar and dance. Sometimes I play basketball with friends. My favourite color is red. This is some random text to show how 200 characters look like.";
            //db.SaveChanges();
        }
    }
}
