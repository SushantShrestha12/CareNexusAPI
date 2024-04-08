using CareNexus.Domain.LandingPages;
using CareNexus.Domain.Locations;
using Microsoft.EntityFrameworkCore;

namespace CareNexus.Infrastructure;

public class CareNexusDbContext: DbContext
{
    public CareNexusDbContext(DbContextOptions<CareNexusDbContext> options): base(options)
    {
        
    }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<Signup> Signups { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CareNexusDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}