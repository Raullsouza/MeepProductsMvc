using MeepProductsMvc.Models;
using System.Collections;

namespace MeepProductsMvc.Interfaces
{
    public interface IProdutoService
    {
        // Task<ProdutoOmie> PostOmie(ProdutoOmie produtoOmie);
        Task<IEnumerable<ProdutoViewModel>> GetProdutos();
        Task<ProdutosOmieTeste> PostOmieTeste(ProdutosOmieTeste produtosOmieTeste);
    }
}
