using CareNexus.Application.LandingPages;
using CareNexus.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CareNexus.Controllers;

[ApiController]
[Route("[controller]")]
public class DonationController: ControllerBase
{
    private readonly IMediator _mediator;

    public DonationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IResult> CreateDonation(DonationCreate donation)
    {
        var command = new DonationCreateRequest
        {
            Name = donation.Name,
            Email = donation.Email,
            Amount = donation.Amount
        };

        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
}