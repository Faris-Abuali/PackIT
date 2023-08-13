namespace PackIT.Shared.Abstractions.Domain;

public abstract class AggregateRoot<T>
{
    private bool _versionIncremented;

    private readonly List<IDomainEvent> _events = new();

    public IEnumerable<IDomainEvent> Events => _events;
    
    public T Id { get; protected set; }
    public int Version { get; protected set; }

    protected void AddEvent(IDomainEvent @event)
    {
        if (!_events.Any() && !_versionIncremented)
        {
            Version++;
            _versionIncremented = true;
        }
            
        _events.Add(@event);
    }

    public void ClearEvents() => _events.Clear();
    
    // Once you modify anything within the aggregate, you need to increment this version
    protected void IncrementVersion()
    {
        if (_versionIncremented)
        {
            return;
        }

        Version++;
        _versionIncremented = true;
    }
}