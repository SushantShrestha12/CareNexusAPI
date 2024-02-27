namespace CareNexus.Domain.SharedKernal;

public abstract class AggregateRoot<TId>
{
    protected AggregateRoot()
    {
    }
    public TId Id { get; private set; }
    protected AggregateRoot(TId id)
    {
        Id = id;
    }
}