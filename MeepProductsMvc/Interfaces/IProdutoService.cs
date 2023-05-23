using MeepProductsMvc.Models;
using System.Collections;

namespace MeepProductsMvc.Interfaces
{
    public interface IProdutoService
    {
        // Task<ProdutoOmie> PostOmie(ProdutoOmie produtoOmie);
        Task<IEnumerable<ProdutosOmieTeste>> GetProdutos();
        Task<ProdutosOmieTeste> PostOmieTeste(ProdutosOmieTeste produtosOmieTeste);
        Task<ListarResponse> ListarProdutos();
    }
}
