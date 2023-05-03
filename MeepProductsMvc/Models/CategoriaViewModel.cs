using System.ComponentModel.DataAnnotations;

namespace MeepProductsMvc.Models
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public int PortalId { get; set; }
        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        public string Nome { get; set; }
        public PortalViewModel Portal { get; set; }
        public ICollection<ProdutoViewModel> Produtos { get; set; }
    }
}
