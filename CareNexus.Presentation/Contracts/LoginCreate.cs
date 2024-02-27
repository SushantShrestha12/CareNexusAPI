namespace CareNexus.Contracts;

public class LoginCreate
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}