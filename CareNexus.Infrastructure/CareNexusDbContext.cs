using CareNexus.Domain.LandingPages;
using Microsoft.EntityFrameworkCore;

namespace CareNexus.Infrastructure;

public class CareNexusDbContext: DbContext
{
    public CareNexusDbContext(DbContextOptions<CareNexusDbContext> options): base(options)
    {
        
    }
    
    public DbSet<Signup> Signups { get; set; }
    //public DbSet<Login> Logins { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CareNexusDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}