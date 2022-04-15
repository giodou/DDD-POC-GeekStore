using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GeekStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<EstoqueMinimoAtingidoEvent>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoEventHandler(IProdutoRepository produto)
        {
            _produtoRepository = produto;
        }
        public async Task Handle(EstoqueMinimoAtingidoEvent notification, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(notification.AggregatedId);

            //TODO: Implementar ação ao atingir estoque minimo, ex: Enviar Email
        }
    }
}
