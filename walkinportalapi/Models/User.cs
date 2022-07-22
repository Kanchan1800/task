using System;
using System.Collections.Generic;

namespace walkinportalapi.Models
{
    public partial class User
    {
        public User()
        {
            Applications = new HashSet<Application>();
            Educationalqualifications = new HashSet<Educationalqualification>();
            Professionalqualifications = new HashSet<Professionalqualification>();
            PrefferedRoles = new HashSet<Prefferedrole>();
        }

        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? EmailId { get; set; }
        public string? Password { get; set; }
        public long? PhoneNo { get; set; }
        public string? Status { get; set; }
        public string? PortfolioUrl { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Educationalqualification> Educationalqualifications { get; set; }
        public virtual ICollection<Professionalqualification> Professionalqualifications { get; set; }

        public virtual ICollection<Prefferedrole> PrefferedRoles { get; set; }
    }
}
