using MeepProductsMvc.Interfaces;
using MeepProductsMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeepProductsMvc.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> Index()
        {
            var result = await _produtoService.GetProdutos();
            
            if (result is null)
            {
                return View("Error");
            }
            return View(result);
        }
        public async Task<ActionResult<ProdutoOmie>> CriarProduto([FromBody] ProdutoOmie produtoOmie )
        {
            var result = await _produtoService.PostOmie(produtoOmie);

            if (result is null)
            {
                return View("Error");
            }
            return View(result);
        }

        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> EnviarOmie()
        {
            var result = await _produtoService.PostProdutosEmOutraApi();

            if(result is null)
            { 
                return View("Error"); 
            }
            return View(result);
        }
    }
}
