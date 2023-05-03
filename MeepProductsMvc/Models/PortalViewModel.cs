using System.ComponentModel.DataAnnotations;

namespace MeepProductsMvc.Models
{
    public class PortalViewModel
    {
        public int Id { get; set; }
        public int LocalId { get; set; }
        public LocalViewModel Local { get; set; }
        [Required(ErrorMessage = "O nome do portal é obrigatório")]
        public string Nome { get; set; }
        public ICollection<CategoriaViewModel> Categorias { get; set; }
    }
}
