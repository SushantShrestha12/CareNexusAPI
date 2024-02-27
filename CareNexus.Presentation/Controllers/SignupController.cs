using MediatR;
using CareNexus.Application;
using CareNexus.Application.LandingPages;
using CareNexus.Contracts;
using CareNexus.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CareNexus.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SignupController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly CareNexusDbContext _context;

    public SignupController(IMediator mediator, CareNexusDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }
    
    [HttpPost]
    public async Task<IResult> CreateSignup(SignupCreate signup)
    {
        if (!UserExist(signup.Email))
        {
            if (signup.Password == signup.ConfirmPassword)
            {
                var command = new SignupCreateRequest()
                {
                    FullName = signup.FullName,
                    PhoneNumber = signup.PhoneNumber,
                    Email = signup.Email,
                    Password = signup.Password,
                    ConfirmPassword = signup.ConfirmPassword
                };
                    
                var result = await _mediator.Send(command);
                return Results.Ok(result);
            }
            throw new ArgumentException("Password and confirm password needs to be same.");
        }

        throw new AggregateException("This username or email already exists.");
    }
    
    private bool UserExist(string email)
    {
        var user = _context.Signups.Any(u => u.Email == email);
        
        return user;
    }
}