using System;
using System.Collections.Generic;

namespace walkinportalapi.Models
{
    public partial class Timeslot
    {
        public int Id { get; set; }
        public string? SlotDetails { get; set; }
        public int WalkinId { get; set; }

        public virtual Walkin Walkin { get; set; } = null!;
    }
}
