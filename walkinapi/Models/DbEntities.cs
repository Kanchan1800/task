using Microsoft.EntityFrameworkCore;

namespace walkinapi.Models;

public class DbEntities : DbContext
{
    public DbEntities(DbContextOptions<DbEntities> options) : base(options)
    { }

    public DbSet<Users> Users { get; set; }
    public DbSet<ProfessionalQualification> ProfessionalQualification { get; set; }
    public DbSet<Applicationn> Application { get; set; }

    //public DbFunctions Add(UserDetails user);
   public DbSet<Walkins> Walkin { get; set; }

    // public override int SaveChanges()
    //     {
    //         ChangeTracker.DetectChanges();
 
    //         updateUpdatedProperty<Users>();
    //         updateUpdatedProperty<ProfessionalQualification>();
 
    //         return base.SaveChanges();
    //     }
}