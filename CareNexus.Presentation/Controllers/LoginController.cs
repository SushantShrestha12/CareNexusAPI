using CareNexus.Application.LandingPages;
using CareNexus.Contracts;
using CareNexus.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CareNexus.Controllers;

[ApiController]
[Route("[controller]")]
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
        var signupRecord = new SignupGetRequest();

        if (signupRecord != null)
        {
            if (IsValidUser(login.Email, login.Password))
            {
                return Ok("Access granted");
            }
            else
            {
                return Unauthorized("Invalid email or password");
            }
        }
        else
        {
            return Unauthorized("Invalid email or password");
        }
    }

    private bool IsValidUser(string username, string password)
    {
        var user = _context.Signups.Any(u => u.Email == username);
        var pass = _context.Signups.Any(p => p.Password == password);
        
        return user && pass;
    }
    
}
