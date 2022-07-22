using System;
using System.Collections.Generic;

namespace walkinportalapi.Models
{
    public partial class ProfessionalqualificationHasFamiliartech
    {
        public int ProfessionalQualificationId { get; set; }
        public int FamiliarTechId { get; set; }

        public virtual Familiartech FamiliarTech { get; set; } = null!;
    }
}
