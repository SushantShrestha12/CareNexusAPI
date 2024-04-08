using CareNexus.Domain.Locations;
using CareNexus.Infrastructure;
using MediatR;

namespace CareNexus.Application.Locations;

public class LocationCreateRequest: IRequest<Location>
{
    public string? Address { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
}

public class LocationCreateRequestHandler : IRequestHandler<LocationCreateRequest, Location>
{
    private readonly CareNexusDbContext _context;

    public LocationCreateRequestHandler(CareNexusDbContext context)
    {
        _context = context;
    }
    public async Task<Location> Handle(LocationCreateRequest request, CancellationToken cancellationToken)
    {
        var locationId = Guid.NewGuid();
        var location = new Location(locationId, request.Address, request.Date, request.Time);

        _context.Locations.Add(location);
        await _context.SaveChangesAsync(cancellationToken);

        return location;
    }
}