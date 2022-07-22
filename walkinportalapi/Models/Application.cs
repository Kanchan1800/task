using System;
using System.Collections.Generic;

namespace walkinportalapi.Models
{
    public partial class Application
    {
        public int Id { get; set; }
        public string? Resume { get; set; }
        public int WalkinId { get; set; }
        public int UsersId { get; set; }
        public int TimeslotsId { get; set; }

        public virtual User Users { get; set; } = null!;
       public virtual Walkin Walkin { get; set; } = null!;
    }
}
