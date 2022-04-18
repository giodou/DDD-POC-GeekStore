using System;
using System.Threading.Tasks;
using GeekStore.Catalogo.Application.DTO;
using GeekStore.Catalogo.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeekStore.WebApp.MVC.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public AdminController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        [Route("admin")]
        public async Task<IActionResult> Index()
        {
            var data = await _produtoAppService.ObterTodos();
            return View(data);
        }
        
        [Route("novo-produto")]
        public async Task<IActionResult> NovoProduto()
        {
            return View(await PopularCategorias(new ProdutoDTO()));
        }

        [HttpPost]
        [Route("novo-produto")]
        public async Task<IActionResult> NovoProduto(ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid) return View(await PopularCategorias(produtoDTO));

            await _produtoAppService.AdicionarProduto(produtoDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id)
        {
            return View(await PopularCategorias(await _produtoAppService.ObterPorId(id)));
        }

        [HttpPost]
        [Route("editar-produto")]
        public async Task<IActionResult> AtualizarProduto(Guid id, ProdutoDTO produtoDTO)
        {
            var produto = await PopularCategorias(await _produtoAppService.ObterPorId(id));
            produtoDTO.QuantidadeEstoque = produto.QuantidadeEstoque;

            ModelState.Remove("QuantidadeEstoque");
            if (!ModelState.IsValid) return View(await PopularCategorias(produtoDTO));

            await _produtoAppService.AtualizarProduto(produtoDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id)
        {
            return View("Estoque", await _produtoAppService.ObterPorId(id));
        }

        [HttpPost]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id, int quantidade)
        {
            if (quantidade > 0)
            {
                await _produtoAppService.ReporEstoque(id, quantidade);
            }
            else
            {
                await _produtoAppService.DebitarEstoque(id, quantidade);
            }

            return View("Index", await _produtoAppService.ObterTodos());
        }

        private async Task<ProdutoDTO> PopularCategorias(ProdutoDTO produtoDTO)
        {
            produtoDTO.Categorias = await _produtoAppService.ObterCategorias();
            return produtoDTO;
        }


    }
}
