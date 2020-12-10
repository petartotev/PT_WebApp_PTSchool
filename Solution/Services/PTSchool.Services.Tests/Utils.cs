using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Data.Models;
using PTSchool.Data.Models.ApiNews;
using PTSchool.Data.Models.Enums;
using PTSchool.Services.Models.ApiNews;
using PTSchool.Services.Models.ApiWeather;
using PTSchool.Services.Models.Class;
using PTSchool.Services.Models.Club;
using PTSchool.Services.Models.Home;
using PTSchool.Services.Models.Mark;
using PTSchool.Services.Models.Note;
using PTSchool.Services.Models.Parent;
using PTSchool.Services.Models.Student;
using PTSchool.Services.Models.Subject;
using PTSchool.Services.Models.Teacher;
using PTSchool.Services.Models.Tictactoe;
using PTSchool.Web.Models.Class;
using PTSchool.Web.Models.Club;
using PTSchool.Web.Models.Home;
using PTSchool.Web.Models.Mark;
using PTSchool.Web.Models.Note;
using PTSchool.Web.Models.Parent;
using PTSchool.Web.Models.Student;
using PTSchool.Web.Models.Subject;
using PTSchool.Web.Models.Teacher;
using System;
using System.Linq;

namespace PTSchool.Services.Tests
{
    public class Utils
    {
        private static MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Article, ArticleServiceModel>();
            cfg.CreateMap<Source, SourceServiceModel>();

            cfg.CreateMap<Class, ClassLightServiceModel>();
            cfg.CreateMap<Class, ClassFullServiceModel>()
                .ForMember(dest => dest.CountStudents, opt => opt.MapFrom(src => src.Students.Count()))
                .ForMember(dest => dest.CountGirls, opt => opt.MapFrom(src => src.Students.Where(x => x.Gender == PTSchool.Data.Models.Enums.EnumGender.Female).Count()))
                .ForMember(dest => dest.CountBoys, opt => opt.MapFrom(src => src.Students.Where(x => x.Gender == PTSchool.Data.Models.Enums.EnumGender.Male).Count()));

            cfg.CreateMap<Club, ClubLightServiceModel>();
            cfg.CreateMap<Club, ClubFullServiceModel>()
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students.Select(x => x.Student)))
                .ForMember(dest => dest.CountStudents, opt => opt.MapFrom(src => src.Students.Count()))
                .ForMember(dest => dest.CountGirls, opt => opt.MapFrom(src => src.Students.Where(x => x.Student.Gender == PTSchool.Data.Models.Enums.EnumGender.Female).Count()))
                .ForMember(dest => dest.CountBoys, opt => opt.MapFrom(src => src.Students.Where(x => x.Student.Gender == PTSchool.Data.Models.Enums.EnumGender.Male).Count()))
                .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.Teachers.Select(x => x.Teacher)))
                .ReverseMap();

            cfg.CreateMap<Mark, MarkLightServiceModel>()
                .ForMember(dest => dest.ValueMark, opt => opt.MapFrom(src => Convert.ToInt32(src.ValueMark)));
            cfg.CreateMap<Mark, MarkFullServiceModel>()
                .ForMember(dest => dest.ValueMark, opt => opt.MapFrom(src => Convert.ToInt32(src.ValueMark)));

            cfg.CreateMap<Note, NoteLightServiceModel>()
                .ForMember(dest => dest.StatusNote, opt => opt.MapFrom(src => Convert.ToInt32(src.StatusNote)));
            cfg.CreateMap<Note, NoteFullServiceModel>()
                .ForMember(dest => dest.StatusNote, opt => opt.MapFrom(src => Convert.ToInt32(src.StatusNote)));

            cfg.CreateMap<Parent, ParentLightServiceModel>();
            cfg.CreateMap<Parent, ParentFullServiceModel>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => (DateTime.UtcNow - src.DateBirth).TotalDays / 365.25))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students.Select(x => x.Student)))
                .ReverseMap();

            cfg.CreateMap<Student, StudentLightServiceModel>();
            cfg.CreateMap<Student, StudentFullServiceModel>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => (DateTime.UtcNow - src.DateBirth).TotalDays / 365.25))
                .ForMember(dest => dest.AverageScore, opt => opt.MapFrom(src => src.Marks.Select(x => (int)x.ValueMark).DefaultIfEmpty(0).Average()))
                .ForMember(dest => dest.AverageBehavior, opt => opt.MapFrom(src => src.Notes.Select(x => (int)x.StatusNote).DefaultIfEmpty(0).Average()))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Parents, opt => opt.MapFrom(src => src.Parents.Select(x => x.Parent)))
                .ForMember(dest => dest.Clubs, opt => opt.MapFrom(src => src.Clubs.Select(x => x.Club)));

            cfg.CreateMap<Subject, SubjectLightServiceModel>();
            cfg.CreateMap<Subject, SubjectFullServiceModel>()
                .ForMember(dest => dest.Classes, opt => opt.MapFrom(src => src.Classes.Select(x => x.Class)))
                .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.Teachers.Select(x => x.Teacher)))
                .ReverseMap();

            cfg.CreateMap<Teacher, TeacherLightServiceModel>();
            cfg.CreateMap<TeacherLightServiceModel, Teacher>();
            cfg.CreateMap<Teacher, TeacherFullServiceModel>()
                .ForMember(dest => dest.AverageMark, opt => opt.MapFrom(src => src.Marks.Select(x => (int)x.ValueMark).DefaultIfEmpty(0).Average()))
                .ForMember(dest => dest.AverageNote, opt => opt.MapFrom(src => src.Notes.Select(x => (int)x.StatusNote).DefaultIfEmpty(0).Average()))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => (DateTime.UtcNow - src.DateBirth).TotalDays / 365.25))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.Clubs, opt => opt.MapFrom(src => src.Clubs.Select(x => x.Club)))
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.Subjects.Select(x => x.Subject)))
                .ReverseMap();

            cfg.CreateMap<Tictactoe, TictactoeServiceModel>();

            // Service Models <> View Models

            cfg.CreateMap<ArticleServiceModel, ArticleViewModel>();
            cfg.CreateMap<SourceServiceModel, SourceViewModel>();

            cfg.CreateMap<HomeServiceModel, HomeViewModel>();

            cfg.CreateMap<RootWeatherServiceModel, WeatherViewModel>()
                .ForMember(dest => dest.CountryWeather, opt => opt.MapFrom(src => src.sys.country))
                .ForMember(dest => dest.CityWeather, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.TempWeather, opt => opt.MapFrom(src => src.main.temp))
                .ForMember(dest => dest.CloudsWeather, opt => opt.MapFrom(src => src.clouds.all))
                .ForMember(dest => dest.HumidityWeather, opt => opt.MapFrom(src => src.main.humidity))
                .ForMember(dest => dest.PressureWeather, opt => opt.MapFrom(src => src.main.pressure))
                .ForMember(dest => dest.WindDirectionWeather, opt => opt.MapFrom(src => src.wind.deg))
                .ForMember(dest => dest.WindSpeedWeather, opt => opt.MapFrom(src => src.wind.speed));

            cfg.CreateMap<ClassLightServiceModel, ClassLightViewModel>().ReverseMap();
            cfg.CreateMap<ClassFullServiceModel, ClassFullViewModel>().ReverseMap();

            cfg.CreateMap<ClubLightServiceModel, ClubLightViewModel>().ReverseMap();
            cfg.CreateMap<ClubFullServiceModel, ClubFullViewModel>().ReverseMap();

            cfg.CreateMap<MarkLightServiceModel, MarkLightViewModel>().ReverseMap();
            cfg.CreateMap<MarkFullServiceModel, MarkFullViewModel>().ReverseMap();

            cfg.CreateMap<NoteLightServiceModel, NoteLightViewModel>().ReverseMap();
            cfg.CreateMap<NoteFullServiceModel, NoteFullViewModel>().ReverseMap();

            cfg.CreateMap<ParentLightServiceModel, ParentLightViewModel>().ReverseMap();
            cfg.CreateMap<ParentFullServiceModel, ParentFullViewModel>().ReverseMap();

            cfg.CreateMap<StudentLightServiceModel, StudentLightViewModel>().ReverseMap();
            cfg.CreateMap<StudentFullServiceModel, StudentFullViewModel>().ReverseMap();

            cfg.CreateMap<SubjectLightServiceModel, SubjectLightViewModel>().ReverseMap();
            cfg.CreateMap<SubjectFullServiceModel, SubjectFullViewModel>().ReverseMap();
            
            cfg.CreateMap<TeacherLightServiceModel, TeacherLightViewModel>().ReverseMap();
            cfg.CreateMap<TeacherFullServiceModel, TeacherFullViewModel>().ReverseMap();
        });

        private static IMapper mapper;

        public static DbContextOptions<PTSchoolDbContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<PTSchoolDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        public static IMapper Mapper
        {
            get
            {
                if (mapper == null)
                {
                    mapper = new Mapper(mapperConfig);
                }

                return mapper;
            }
        }

        public static Teacher CreateMockTeacher(string firstName = "firstName", string middleName = "middleName", string lastName = "lastName", string description = "description", string image = "/images/teachers/default.jpg", EnumGender gender = EnumGender.Male, bool isHeadTeacher = false, string address = "address", string email = "email@email.email", string phone = "phone", string phoneEmergency = "phoneEmergency", bool isBanned = false, bool isDeleted = false)
        {
            return new Teacher
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Description = description,
                Image = image,
                Gender = gender,
                IsHeadTeacher = isHeadTeacher,
                DateBirth = DateTime.Parse("10/10/1980"),
                DateEmployed = DateTime.Parse("10/10/2015"),
                DateCareerStart = DateTime.Parse("10/10/2010"),
                Address = address,
                Email = email,
                Phone = phone,
                PhoneEmergency = phoneEmergency,
                IsBanned = isBanned,
                IsDeleted = isDeleted
            };
        }

        public static Class CreateMockClass(Guid teacherId, string name = "nameClass", string description = "descriptionClass", string image = "imageClass", bool isDeleted = false, bool isUnlisted = false)
        {
            return new Class
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Image = image,
                MasterTeacherId = teacherId,
                IsDeleted = isDeleted,
                IsUnlisted = isUnlisted
            };
        }
    }
}
