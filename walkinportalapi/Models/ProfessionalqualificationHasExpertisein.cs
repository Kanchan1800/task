using System;
using System.Collections.Generic;

namespace walkinportalapi.Models
{
    public partial class ProfessionalqualificationHasExpertisein
    {
        public int ProfessionalQualificationId { get; set; }
        public int ExpertiseInId { get; set; }

        public virtual Expertisein ExpertiseIn { get; set; } = null!;
    }
}
