using MeepProductsMvc.Models;
using System.Collections;

namespace MeepProductsMvc.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutosOmieTeste>> GetProdutos();
        Task<ProdutosOmieTeste> PostOmieTeste(ProdutosOmieTeste produtosOmieTeste);
        Task<ListarResponse> ListarProdutos();
        bool UpdateProduto(ProdutosOmieTeste produtosOmieTeste);
        bool DeleteProduto(ProdutosOmieTeste produtosOmieTeste);
    }
}
