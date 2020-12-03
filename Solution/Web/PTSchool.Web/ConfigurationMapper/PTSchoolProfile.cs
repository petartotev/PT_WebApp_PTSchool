using AutoMapper;
using PTSchool.Data.Models;
using PTSchool.Services.Models.Class;
using PTSchool.Services.Models.Club;
using PTSchool.Services.Models.Mark;
using PTSchool.Services.Models.Note;
using PTSchool.Services.Models.Parent;
using PTSchool.Services.Models.Student;
using PTSchool.Services.Models.Subject;
using PTSchool.Services.Models.Teacher;
using PTSchool.Services.Models.Tictactoe;
using PTSchool.Web.Models.Class;
using PTSchool.Web.Models.Club;
using PTSchool.Web.Models.Mark;
using PTSchool.Web.Models.Note;
using PTSchool.Web.Models.Parent;
using PTSchool.Web.Models.Student;
using PTSchool.Web.Models.Subject;
using PTSchool.Web.Models.Teacher;
using System;
using System.Linq;

namespace PTSchool.Web.ConfigurationMapper
{
    public class PTSchoolProfile : Profile
    {
        public PTSchoolProfile()
        {
            // Data Models > Service Models

            CreateMap<Class, ClassLightServiceModel>();
            CreateMap<Class, ClassFullServiceModel>()
                .ForMember(dest => dest.CountStudents, opt => opt.MapFrom(src => src.Students.Count()))
                .ForMember(dest => dest.CountGirls, opt => opt.MapFrom(src => src.Students.Where(x => x.Gender == PTSchool.Data.Models.Enums.EnumGender.Female).Count()))
                .ForMember(dest => dest.CountBoys, opt => opt.MapFrom(src => src.Students.Where(x => x.Gender == PTSchool.Data.Models.Enums.EnumGender.Male).Count()));

            CreateMap<Club, ClubLightServiceModel>();
            CreateMap<Club, ClubFullServiceModel>()
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students.Select(x => x.Student)))
                .ForMember(dest => dest.CountStudents, opt => opt.MapFrom(src => src.Students.Count()))
                .ForMember(dest => dest.CountGirls, opt => opt.MapFrom(src => src.Students.Where(x => x.Student.Gender == PTSchool.Data.Models.Enums.EnumGender.Female).Count()))
                .ForMember(dest => dest.CountBoys, opt => opt.MapFrom(src => src.Students.Where(x => x.Student.Gender == PTSchool.Data.Models.Enums.EnumGender.Male).Count()))
                .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.Teachers.Select(x => x.Teacher)));

            CreateMap<Mark, MarkLightServiceModel>()
                .ForMember(dest => dest.ValueMark, opt => opt.MapFrom(src => Convert.ToInt32(src.ValueMark)));
            CreateMap<Mark, MarkFullServiceModel>()
                .ForMember(dest => dest.ValueMark, opt => opt.MapFrom(src => Convert.ToInt32(src.ValueMark)));

            CreateMap<Note, NoteLightServiceModel>()
                .ForMember(dest => dest.StatusNote, opt => opt.MapFrom(src => Convert.ToInt32(src.StatusNote)));
            CreateMap<Note, NoteFullServiceModel>()
                .ForMember(dest => dest.StatusNote, opt => opt.MapFrom(src => Convert.ToInt32(src.StatusNote)));

            CreateMap<Parent, ParentLightServiceModel>();
            CreateMap<Parent, ParentFullServiceModel>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => (DateTime.UtcNow - src.DateBirth).TotalDays / 365.25))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students.Select(x => x.Student)));

            CreateMap<Student, StudentLightServiceModel>();
            CreateMap<Student, StudentFullServiceModel>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => (DateTime.UtcNow - src.DateBirth).TotalDays / 365.25))
                .ForMember(dest => dest.AverageScore, opt => opt.MapFrom(src => src.Marks.Select(x => (int)x.ValueMark).DefaultIfEmpty(0).Average()))
                .ForMember(dest => dest.AverageBehavior, opt => opt.MapFrom(src => src.Notes.Select(x => (int)x.StatusNote).DefaultIfEmpty(0).Average()))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.Parents, opt => opt.MapFrom(src => src.Parents.Select(x => x.Parent)))
                .ForMember(dest => dest.Clubs, opt => opt.MapFrom(src => src.Clubs.Select(x => x.Club)));

            CreateMap<Subject, SubjectLightServiceModel>();
            CreateMap<Subject, SubjectFullServiceModel>()
                .ForMember(dest => dest.Classes, opt => opt.MapFrom(src => src.Classes.Select(x => x.Class)))
                .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.Teachers.Select(x => x.Teacher)));

            CreateMap<Teacher, TeacherLightServiceModel>();
            CreateMap<Teacher, TeacherFullServiceModel>()
                .ForMember(dest => dest.AverageMark, opt => opt.MapFrom(src => src.Marks.Select(x => (int)x.ValueMark).DefaultIfEmpty(0).Average()))
                .ForMember(dest => dest.AverageNote, opt => opt.MapFrom(src => src.Notes.Select(x => (int)x.StatusNote).DefaultIfEmpty(0).Average()))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => (DateTime.UtcNow - src.DateBirth).TotalDays / 365.25))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.Clubs, opt => opt.MapFrom(src => src.Clubs.Select(x => x.Club)))
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.Subjects.Select(x => x.Subject)));

            CreateMap<Tictactoe, TictactoeServiceModel>();

            // Service Models <> View Models

            CreateMap<ClassLightServiceModel, ClassLightViewModel>().ReverseMap();
            CreateMap<ClassFullServiceModel, ClassFullViewModel>().ReverseMap();

            CreateMap<ClubLightServiceModel, ClubLightViewModel>().ReverseMap();
            CreateMap<ClubFullServiceModel, ClubFullViewModel>().ReverseMap();

            CreateMap<MarkLightServiceModel, MarkLightViewModel>().ReverseMap();
            CreateMap<MarkFullServiceModel, MarkFullViewModel>().ReverseMap();

            CreateMap<NoteLightServiceModel, NoteLightViewModel>().ReverseMap();
            CreateMap<NoteFullServiceModel, NoteFullViewModel>().ReverseMap();

            CreateMap<ParentLightServiceModel, ParentLightViewModel>().ReverseMap();
            CreateMap<ParentFullServiceModel, ParentFullViewModel>().ReverseMap();

            CreateMap<StudentLightServiceModel, StudentLightViewModel>().ReverseMap();
            CreateMap<StudentFullServiceModel, StudentFullViewModel>().ReverseMap();

            CreateMap<SubjectLightServiceModel, SubjectLightViewModel>().ReverseMap();
            CreateMap<SubjectFullServiceModel, SubjectFullViewModel>().ReverseMap();

            CreateMap<TeacherLightServiceModel, TeacherLightViewModel>().ReverseMap();
            CreateMap<TeacherFullServiceModel, TeacherFullViewModel>().ReverseMap();
        }
    }
}
