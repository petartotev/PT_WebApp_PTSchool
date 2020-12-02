using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Models.Abstracts
{
    public class PageableCollection
    {
        public virtual string Url { get; set; }

        public virtual int PageSize { get; set; }

        public virtual int CurrentPage { get; set; }

        public virtual int TotalCount { get; set; }

        public virtual int FirstPage => 1;

        public virtual int LastPage
        {
            get
            {
                return (int)Math.Ceiling((double)this.TotalCount / this.PageSize);
            }
        }

        public virtual int PreviousPage => this.CurrentPage - 1;

        public virtual int NextPage => this.CurrentPage + 1;

        public virtual bool IsPreviousPageDisabled => this.CurrentPage == 1;

        public virtual bool IsNextPageDisabled
        {
            get
            {
                return CurrentPage == Math.Ceiling((double)this.TotalCount / this.PageSize);
            }
        }
    }
}
