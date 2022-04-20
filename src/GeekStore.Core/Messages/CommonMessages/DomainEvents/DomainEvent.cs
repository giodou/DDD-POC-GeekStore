using System;

namespace GeekStore.Core.Messages.CommonMessages.DomainEvents
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregatedId)
        {
            AggregatedId = aggregatedId;
        }
    }
}
