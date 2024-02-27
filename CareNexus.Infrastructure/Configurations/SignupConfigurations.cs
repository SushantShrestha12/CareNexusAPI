using CareNexus.Domain.LandingPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareNexus.Infrastructure.Configurations;

public class SignupConfiguration: IEntityTypeConfiguration<Signup>
{
    public void Configure(EntityTypeBuilder<Signup> builder)
    {
        builder.HasKey(o => o.Id);
    }
}