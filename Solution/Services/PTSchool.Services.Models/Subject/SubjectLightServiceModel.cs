using System;

namespace PTSchool.Services.Models.Subject
{
    public class SubjectLightServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsUnlisted { get; set; }
    }
}
