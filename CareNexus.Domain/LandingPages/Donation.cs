using CareNexus.Domain.SharedKernal;

namespace CareNexus.Domain.LandingPages;

public class Donation: AggregateRoot<Guid>
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public decimal Amount { get; private set; }

    public Donation(Guid id, string name, string email, decimal amount):base(id)
    {
        Name = name;
        Email = email;
        Amount = amount;
    }
}