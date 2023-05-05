using MeepProductsMvc.Interfaces;
using MeepProductsMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;

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

        [HttpGet]
        public IActionResult CriarProduto()
        { 
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<ProdutoOmie>> CriarProduto(ProdutoOmie produtoOmie)
        {
            if (ModelState.IsValid)
            {
                var result = await _produtoService.PostOmie(produtoOmie);

                if (result != null)
                    return RedirectToAction(nameof(Index));
            }
                ViewBag.Erro = "Erro ao criar o produto";
                return View(produtoOmie);  
        }
    }
}
