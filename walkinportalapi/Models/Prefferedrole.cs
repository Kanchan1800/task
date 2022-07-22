using System;
using System.Collections.Generic;

namespace walkinportalapi.Models
{
    public partial class Prefferedrole
    {
        public Prefferedrole()
        {
            Users = new HashSet<User>();
        }

        public int PrefferedRolesId { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
