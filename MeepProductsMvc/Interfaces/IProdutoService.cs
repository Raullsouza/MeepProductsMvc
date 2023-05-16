using MeepProductsMvc.Models;

namespace MeepProductsMvc.Interfaces
{
    public interface IProdutoService
    {
        // Task<ProdutoOmie> PostOmie(ProdutoOmie produtoOmie);
        Task<IEnumerable<ProdutoViewModel>> GetProdutos();
        Task<ParamObject> PostOmieTeste();
    }
}
