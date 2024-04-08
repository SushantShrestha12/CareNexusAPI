namespace CareNexus.Contracts;

public class LocationCreate
{
    public string? Address { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
}