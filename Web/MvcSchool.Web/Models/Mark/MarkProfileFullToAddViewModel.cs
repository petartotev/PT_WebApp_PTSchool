using Microsoft.CodeAnalysis.CSharp.Syntax;
using MvcSchool.Data.Models;
using MvcSchool.Services.Models.Mark;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MvcSchool.Web.Models.Mark
{
    public class MarkProfileFullToAddViewModel
    {
        public string Title { get; set; }

        public string Comment { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateReceived { get; set; } = DateTime.Now;

        public DateTime DateConfirmed { get; set; }

        public int StudentId { get; set; }

        public int TeacherId { get; set; }

        public Subject Subject { get; set; }

        public EnumValueMark ValueMark { get; set; } = EnumValueMark.Excellent;
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
