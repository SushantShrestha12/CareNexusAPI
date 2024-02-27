using CareNexus.Domain.SharedKernal;

namespace CareNexus.Domain.LandingPages;

public class Signup: AggregateRoot<Guid>
{
    private Signup(){}

    public string FullName { get; private set; } 
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; } 
    public string Password { get; private set; } 
    public string ConfirmPassword { get; private set; } 

    public Signup(Guid id, string fullName, string phoneNumber, string email, string password, string confirmPassword): base(id)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
    }
}