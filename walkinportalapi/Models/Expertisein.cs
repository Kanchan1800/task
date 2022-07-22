using System;
using System.Collections.Generic;

namespace walkinportalapi.Models
{
    public partial class Expertisein
    {
        public Expertisein()
        {
            ProfessionalqualificationHasExpertiseins = new HashSet<ProfessionalqualificationHasExpertisein>();
        }

        public int ExpertiseInId { get; set; }
        public string? TechName { get; set; }

        public virtual ICollection<ProfessionalqualificationHasExpertisein> ProfessionalqualificationHasExpertiseins { get; set; }
    }
}
