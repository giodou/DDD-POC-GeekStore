using System;
using System.Threading.Tasks;
using GeekStore.Catalogo.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeekStore.WebApp.MVC.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public CatalogoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        [Route("")]
        [Route("catalogo")]
        public async Task<IActionResult> Index()
        {
            return View(await _produtoAppService.ObterTodos());
        }

        [HttpGet]
        [Route("produto-detalhe/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            return View(await _produtoAppService.ObterPorId(id));
        }
    }
}
