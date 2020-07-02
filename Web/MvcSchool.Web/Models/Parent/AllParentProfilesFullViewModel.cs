using MvcSchool.Services.Models.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSchool.Web.Models.Parent
{
    public class AllParentProfilesFullViewModel
    {
        public IEnumerable<ParentProfileFullServiceModel> AllParentsFull { get; set; }


        public int CurrentPage { get; set; }

        public int FirstPage => 1;

        public int LastPage
        {
            get
            {
                return (int)Math.Ceiling((double)this.Total / 25);
            }
        }


        public int PreviousPage => this.CurrentPage - 1;

        public int NextPage => this.CurrentPage + 1;


        public bool PreviousDisabled => this.CurrentPage == 1;

        public bool NextDisabled
        {
            get
            {
                var maxPage = Math.Ceiling((double)this.Total / 25);

                return maxPage == this.CurrentPage;
            }
        }


        public int Total { get; set; }        
    }
}
