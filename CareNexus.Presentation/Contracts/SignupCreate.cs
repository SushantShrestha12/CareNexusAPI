namespace CareNexus.Contracts;

public class SignupCreate
{
    public string FullName { get;  set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    
}