using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public DateTime DateCreated { get; set; }

        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsBanned { get; set; }
    }
}
