using System;
using System.Threading.Tasks;
using GeekStore.Catalogo.Application.Services;
using GeekStore.Core.Communication.Mediator;
using GeekStore.Core.Messages.CommonMessages.Notifications;
using GeekStore.Vendas.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeekStore.WebApp.MVC.Controllers
{
    public class CarrinhoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IMediatorHandler _mediatorHandler;

        public CarrinhoController(INotificationHandler<DomainNotification> domainNotificationHandler, 
                                  IProdutoAppService produtoAppService, 
                                  IMediatorHandler mediatorHandler) 
            : base(domainNotificationHandler, mediatorHandler)
        {
            _produtoAppService = produtoAppService;
            _mediatorHandler = mediatorHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            if (produto == null) return BadRequest();

            if (produto.QuantidadeEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com estoque insuficiente";
                return RedirectToAction("ProdutoDetalhe", "Catalogo", new {id});
            }

            var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);
            await _mediatorHandler.SendCommand(command);

            if (OperacaoValida())
            {
                return RedirectToAction("Index");
            }

            TempData["Erros"] = ObterMensagensErro();
            return RedirectToAction("ProdutoDetalhe", "Catalogo", new {id});
        }
    }
}
