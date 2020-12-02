using PTSchool.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PTSchool.Web.Models.Mark
{
    public class MarkFullViewModel
    {
        //public string Title { get; set; }

        //public string Comment { get; set; }

        //[DataType(DataType.DateTime)]
        //public DateTime DateReceived { get; set; } = DateTime.Now;

        //public DateTime DateConfirmed { get; set; }

        //public int StudentId { get; set; }

        //public int TeacherId { get; set; }

        //public SubjectMark Subject { get; set; }

        //public EnumValueMark ValueMark { get; set; } = EnumValueMark.Excellent;
    }

    public enum SubjectMark
    {
        InformationTechnology = 1,
        Mathematics = 2,
        BulgarianLanguage = 3,
        English = 4,
        German = 5,
        Biology = 6,
        History = 7,
        Geography = 8,
        Philosophy = 9,
        Chemistry = 10,
        WorldAndPerson = 11,
        Physics = 12,
        Music = 13,
        Arts = 14,
        Sports = 15,
        TrafficSafety = 16
    }
}
