using GeekStore.Catalogo.Application.Services;
using GeekStore.Catalogo.Data;
using GeekStore.Catalogo.Data.Repository;
using GeekStore.Catalogo.Domain;
using GeekStore.Core.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace GeekStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Domain Bus (Mediator)
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            //Catálogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();
        }
    }
}