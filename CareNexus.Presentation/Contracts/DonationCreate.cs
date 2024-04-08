namespace CareNexus.Contracts;

public class DonationCreate
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public decimal Amount { get; set; }
}