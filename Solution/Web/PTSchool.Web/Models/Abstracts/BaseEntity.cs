using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Models.Abstracts
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Image { get; set; }
        public virtual string Description { get; set; }
    }
}
