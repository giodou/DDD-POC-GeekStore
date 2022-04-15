using GeekStore.Core.DomainObjects;
using System;

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
