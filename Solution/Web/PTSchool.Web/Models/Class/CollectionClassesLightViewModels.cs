using PTSchool.Web.Models.Abstracts;
using System;
using System.Collections.Generic;

namespace PTSchool.Web.Models.Class
{
    public class CollectionClassesLightViewModels : PageableCollection
    {
        public IEnumerable<ClassLightViewModel> Classes { get; set; }        
    }
}
