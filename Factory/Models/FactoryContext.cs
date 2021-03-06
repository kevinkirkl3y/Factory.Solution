using Microsoft.EntityFrameworkCore; 

namespace Factory.Models
{
  public class FactoryContext : DbContext
  {
    public DbSet<Engineer> Engineers { get; set; }
    public virtual DbSet<Machine> Machines { get; set; }
    public DbSet<License> Licenses { get; set; }
    public DbSet<LicenseEngineer> LicenseEngineer { get; set; }
    public DbSet<MachineLicense> MachineLicense { get; set; }
    public FactoryContext(DbContextOptions options) : base(options) { }
  }
}