using System;
using System.Collections.Generic;

namespace walkinportalapi.Models
{
    public partial class Walkin
    {
        public Walkin()
        {
            Applications = new HashSet<Application>();
            RolesNavigation = new HashSet<Role>();
            Timeslots = new HashSet<Timeslot>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Duration { get; set; }
        public string? Roles { get; set; }
        public string? Location { get; set; }
        public string? GeneralInstructions { get; set; }
        public string? ExamInstructions { get; set; }
        public string? SystemRequirements { get; set; }
        public string? ExpiresIn { get; set; }
        public string? InternshipDetaisl { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Role> RolesNavigation { get; set; }
        public virtual ICollection<Timeslot> Timeslots { get; set; }
    }
}
