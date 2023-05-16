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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> Index()
        {
            var result = await _produtoService.GetProdutos();

            if (result is null)
            {
                return View("Error");
            }
            return View(result);
        }

        [HttpGet("CriarProduto")]
          public IActionResult CriarProduto(ProdutosOmieTeste produtosOmieTeste) 
          { 
              return View();
          }
     /*  
        [HttpPost("CriarProduto")]
        public async Task<ActionResult<ProdutoOmie>> CriarProduto(ProdutoOmie produtoOmie)
        {
            if (ModelState.IsValid)
            {
                var result = await _produtoService.PostOmieTeste();

                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            ViewBag.Erro = "Erro ao criar o produto";
            return View();
        }
     */
        [HttpPost("CriarProduto")]
        public async Task<ActionResult<ProdutosOmieTeste>> CriarProduto()
        {
            if (ModelState.IsValid)
            {
                var result = await _produtoService.PostOmieTeste();

                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
            ViewBag.Erro = "Erro ao criar o produto";
            return View();
        }
    }
}
