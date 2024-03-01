using CareNexus.Domain.LandingPages;
using CareNexus.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CareNexus.Application.LandingPages;
public class SignupGetRequest: IRequest<List<Signup>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class SignupGetRequestHandler : IRequestHandler<SignupCreateRequest, List<Signup>>
{
    private readonly CareNexusDbContext _context;

    public SignupGetRequestHandler(CareNexusDbContext context)
    {
        _context = context;
    }
    public async Task<List<Signup>> Handle(SignupCreateRequest request, CancellationToken cancellationToken)
    {
        return await _context.Signups.ToListAsync();
    }
}