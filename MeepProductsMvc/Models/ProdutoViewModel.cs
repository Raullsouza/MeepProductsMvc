
using System.ComponentModel.DataAnnotations;

namespace MeepProductsMvc.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public int? Ncm { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}