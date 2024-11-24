﻿

namespace Idm.Domain.Abstractions
{
    public class Aggregate<TId> : Entity<TId>, IAggregate<TId>
    {
        private readonly List<IDomainEvent> _events = new();
        public IReadOnlyList<IDomainEvent> Events => _events.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }

        public IDomainEvent[] ClearDomainEvents()
        {
            IDomainEvent[] dequeuedEvents = _events.ToArray();

            _events.Clear();

            return dequeuedEvents;
        }
    }
}
