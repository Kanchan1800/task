using System;
using System.Collections.Generic;

namespace walkinportalapi.Models
{
    public partial class Familiartech
    {
        public Familiartech()
        {
            ProfessionalqualificationHasFamiliarteches = new HashSet<ProfessionalqualificationHasFamiliartech>();
        }

        public int FamiliarTechId { get; set; }
        public string? TechName { get; set; }

        public virtual ICollection<ProfessionalqualificationHasFamiliartech> ProfessionalqualificationHasFamiliarteches { get; set; }
    }
}
