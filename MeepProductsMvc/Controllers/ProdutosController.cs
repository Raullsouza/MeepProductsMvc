using MeepProductsMvc.Exceptions;
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
        /*
                [HttpGet]
                public async Task<ActionResult<IEnumerable<ProdutosOmieTeste>>> Index()
                {
                    var result = await _produtoService.GetProdutos();

                    if (result is null)
                    {
                        return View("Error");
                    }
                    return View(result);
                }

        */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListarProdutosOmie>>> Index()
        {
            var result = await _produtoService.ListarProdutos();
            var responseContent = result.produto_servico_resumido[0];

            if (result is null)
            {
                return View("Error");
            }
           return View(result.produto_servico_resumido);
        }

        [HttpGet("CriarProduto")]
          public IActionResult CriarProduto() 
          { 
              return View();
          }

        [HttpPost("CriarProduto")]
        public async Task<ActionResult<ProdutosOmieTeste>> CriarProduto(ProdutosOmieTeste produtosOmieTeste)
        {
            if (ModelState.IsValid)
            {
                var result = await _produtoService.PostOmieTeste(produtosOmieTeste);

                if (result == null )
                    return RedirectToAction(nameof(Index));
            }
            ViewBag.Erro = "Erro ao criar o produto";
            return View();
        }
    }
}