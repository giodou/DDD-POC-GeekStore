using GeekStore.Core.DomainObjects;
using System;
using GeekStore.Core.Messages.CommonMessages.DomainEvents;

namespace GeekStore.Catalogo.Domain.Events
{
    public class EstoqueMinimoAtingidoEvent : DomainEvent
    {
        public int QuantidadeRestante { get; private set; }
        public EstoqueMinimoAtingidoEvent(Guid aggregatedId, int quantidadeRestante) : base(aggregatedId)
        {
            QuantidadeRestante = quantidadeRestante;
        }
    }
}
