using GeekStore.Catalogo.Application.Services;
using GeekStore.Catalogo.Data;
using GeekStore.Catalogo.Data.Repository;
using GeekStore.Catalogo.Domain;
using GeekStore.Catalogo.Domain.Events;
using GeekStore.Core.Communication.Mediator;
using GeekStore.Core.Messages.CommonMessages.Notifications;
using GeekStore.Vendas.Application.Commands;
using GeekStore.Vendas.Data.Repository;
using GeekStore.Vendas.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GeekStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Catálogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<EstoqueMinimoAtingidoEvent>, ProdutoEventHandler>();

            //Vendas
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();

        }
    }
}