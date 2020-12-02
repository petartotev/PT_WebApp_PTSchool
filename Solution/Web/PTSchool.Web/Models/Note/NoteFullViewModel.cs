using PTSchool.Data.Models;
using PTSchool.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Models.Note
{
    public class NoteFullViewModel
    {
        //public string Title { get; set; }

        //public string Comment { get; set; }

        //public DateTime DateReceived { get; set; } = DateTime.Now;

        //public DateTime DateConfirmed { get; set; }

        //public int StudentId { get; set; }

        //public int TeacherId { get; set; }

        //public SubjectNote Subject { get; set; }

        //public EnumStatusNote StatusNote { get; set; }        
    }

    public enum SubjectNote
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
