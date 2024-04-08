using CareNexus.Domain.SharedKernal;

namespace CareNexus.Domain.Locations;

public class Location: AggregateRoot<Guid>
{
    private Location() { }
    public string? Address { get; private set; }
    public DateOnly Date { get; private set; }
    public TimeOnly Time { get; private set; }

    public Location(Guid id, string address, DateOnly date, TimeOnly time):base(id)
    {
        Address = address;
        Date = date;
        Time = time;
    }
}