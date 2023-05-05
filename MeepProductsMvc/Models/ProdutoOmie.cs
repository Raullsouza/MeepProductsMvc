

namespace MeepProductsMvc.Models
{
    public class ProdutoOmie
    {
        public string call { get; set; }
        public string app_key { get; set; }
        public string app_secret { get; set; }
        public Param[] param { get; set; }

    }
    public class Param
    {
        public string codigo_produto_integracao { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string unidade { get; set; }
        public string ncm { get; set; }
    }
}
