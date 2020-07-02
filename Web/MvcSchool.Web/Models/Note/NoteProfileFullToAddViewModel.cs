using MvcSchool.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Models.Note
{
    public class NoteProfileFullToAddViewModel
    {
        public string Title { get; set; }

        public string Comment { get; set; }

        public DateTime DateReceived { get; set; } = DateTime.Now;

        public DateTime DateConfirmed { get; set; }

        public int StudentId { get; set; }

        public int TeacherId { get; set; }

        public Subject Subject { get; set; }

        public EnumStatusNote StatusNote { get; set; }        
    }

    public enum Subject
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
