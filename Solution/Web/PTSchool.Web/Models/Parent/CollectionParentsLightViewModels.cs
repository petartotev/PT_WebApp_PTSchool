using PTSchool.Services.Models.Parent;
using PTSchool.Web.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Models.Parent
{
    public class CollectionParentsLightViewModels : PageableCollection
    {
        public IEnumerable<ParentLightViewModel> Parents { get; set; }
    }
}
