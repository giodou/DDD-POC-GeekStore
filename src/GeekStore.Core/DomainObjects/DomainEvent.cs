using GeekStore.Core.Messages;
using System;

namespace GeekStore.Core.DomainObjects
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregatedId)
        {
            AggregatedId = aggregatedId;
        }
    }
}
