using MeepProductsMvc.Models;

namespace MeepProductsMvc.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoViewModel>> GetProdutos();
        Task<ProdutoViewModel> GetProdutoById(int id);
        Task<ProdutoViewModel> CriaProduto(ProdutoViewModel produtoVM);
        Task<bool> AtualizaProduto(int id, ProdutoViewModel produtoVM);
        Task<bool> DeletaProduto(int id);
        Task<IEnumerable<ProdutoViewModel>> PostProdutosEmOutraApi();
        Task<ProdutoOmie> PostOmie(ProdutoOmie produtoOmie);
    }
}
