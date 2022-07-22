using System;
using System.Collections.Generic;

namespace walkinportalapi.Models
{
    public partial class Educationalqualification
    {
        public int EducationalQualificationsId { get; set; }
        public int? Percentage { get; set; }
        public string? College { get; set; }
        public string? Qualification { get; set; }
        public string? Stream { get; set; }
        public string? PassingYear { get; set; }
        public string? CollegeLocation { get; set; }
        public int UsersId { get; set; }

        public virtual User Users { get; set; } = null!;
    }
}
