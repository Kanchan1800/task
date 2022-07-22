using System;
using System.Collections.Generic;

namespace walkinportalapi.Models
{
    public partial class Professionalqualification
    {
        public int Id { get; set; }
        public bool? IsFresher { get; set; }
        public string? ExperienceYears { get; set; }
        public string? CurrentCtc { get; set; }
        public string? ExpectedCtc { get; set; }
        public bool? OnNoticePeriod { get; set; }
        public string? NoticePeriodEnds { get; set; }
        public string? NoticeDuration { get; set; }
        public bool? AppliedBefore { get; set; }
        public string? RoleBefore { get; set; }
        public int UsersId { get; set; }
        public bool? GivenZeusTest { get; set; }

        public virtual User Users { get; set; } = null!;
    }
}
