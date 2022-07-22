using System;
using System.Collections.Generic;

namespace walkinportalapi.Models
{
    public partial class Role
    {
        public int Id { get; set; }
        public int WalkinId { get; set; }
        public string? RoleTitle { get; set; }
        public string? Package { get; set; }
        public string? Description { get; set; }
        public string? Requirements { get; set; }
        public string? ProcessDescription { get; set; }

        public virtual Walkin Walkin { get; set; } = null!;
    }
}
