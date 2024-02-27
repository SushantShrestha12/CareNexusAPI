using CareNexus.Application.LandingPages;
using CareNexus.Contracts;
using CareNexus.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CareNexus.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class LoginController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly CareNexusDbContext _context;
    
    public LoginController(IMediator mediator, CareNexusDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> GetAccess(LoginCreate login)
    {
        if (IsValidUser(login.Email, login.Password))
        {
            var command = new LoginCreateRequest
            {
                Email = login.Email,
                Password = login.Password
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        return Unauthorized();
    }

    private bool IsValidUser(string username, string password)
    {
        var user = _context.Signups.Any(u => u.Email == username);
        var pass = _context.Signups.Any(p => p.Password == password);
        
        return user && pass;
    }
    
}
