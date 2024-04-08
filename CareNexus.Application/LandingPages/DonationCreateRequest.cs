using CareNexus.Domain.LandingPages;
using CareNexus.Infrastructure;
using MediatR;

namespace CareNexus.Application.LandingPages;

public class DonationCreateRequest: IRequest<Donation>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Amount { get; set; }
}

public class DonationCreateRequestHandler : IRequestHandler<DonationCreateRequest, Donation>
{
    private readonly CareNexusDbContext _context;

    public DonationCreateRequestHandler(CareNexusDbContext context)
    {
        _context = context;
    }
    public async Task<Donation> Handle(DonationCreateRequest request, CancellationToken cancellationToken)
    {
        var donationId = Guid.NewGuid();
        var donation = new Donation(donationId, request.Name, request.Email, request.Amount);

        _context.Donations.Add(donation);
        await _context.SaveChangesAsync(cancellationToken);

        return donation;
    }
}