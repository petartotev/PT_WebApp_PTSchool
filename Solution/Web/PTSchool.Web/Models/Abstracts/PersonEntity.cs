using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Models.Abstracts
{
    public abstract class PersonEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Image { get; set; }
        public virtual string Description { get; set; }
        public virtual string Gender { get; set; }
        public virtual int Age { get; set; }
        public virtual DateTime DateBirth { get; set; }

        public virtual string Address { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string PhoneEmergency { get; set; }
    }
}
