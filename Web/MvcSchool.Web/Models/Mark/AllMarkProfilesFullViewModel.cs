using MvcSchool.Services.Models.Mark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Models.Mark
{
    public class AllMarkProfilesFullViewModel
    {
        public IEnumerable<MarkProfileFullServiceModel> MarkProfilesFull { get; set; }

        public bool IsAllMarksSignedByParent { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public int TotalCount { get; set; }

        public int FirstPage = 1;

        public int LastPage
        {
            get
            {
                return (int)Math.Ceiling((double)this.TotalCount / this.PageSize);
            }
        }

        public int PreviousPage => this.CurrentPage - 1;
        public int NextPage => this.CurrentPage + 1;

        public bool IsPreviousDisabled => this.CurrentPage == 1;

        public bool IsNextDisabled
        {
            get
            {
                return CurrentPage == Math.Ceiling((double)this.TotalCount / this.PageSize);
            }
        }
    }
}
