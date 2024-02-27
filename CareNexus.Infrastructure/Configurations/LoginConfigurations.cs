using CareNexus.Domain.LandingPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareNexus.Infrastructure.Configurations;

public class LoginConfiguration: IEntityTypeConfiguration<Login>
{
    public void Configure(EntityTypeBuilder<Login> builder)
    {
        builder.HasKey(l => l.Email);
    }
}