using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Models.Home
{
    public class EmailSendViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Subject { get; set; }

        [Required]
        [StringLength(1500)]
        public string Message { get; set; }
    }
}
