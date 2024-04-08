using CareNexus.Application.Locations;
using CareNexus.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CareNexus.Controllers;

[ApiController]
[Route("location")]
public class LocationController: ControllerBase
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IResult> CreateLocation(LocationCreate location)
    {
        var command = new LocationCreateRequest
        {
            Address = location.Address,
            Date = location.Date,
            Time = location.Time
        };
        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
}
