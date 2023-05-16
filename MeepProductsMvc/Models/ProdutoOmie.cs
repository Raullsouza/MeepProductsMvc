using System.Text.Json.Serialization;

namespace MeepProductsMvc.Models
{
    public class ProdutoOmie
    {
        [JsonPropertyName("call")]
        public string? Call { get; set; }

        [JsonPropertyName("app_key")]
        public string? AppKey { get; set; }

        [JsonPropertyName("app_secret")]
        public string? AppSecret { get; set; }

        [JsonPropertyName("param")]
        public Param[]? Param { get; set; }
        
    }

    public class Param
    {
        [JsonPropertyName("codigo_produto_integracao")]
        public string? CodigoProdutoIntegracao { get; set; }

        [JsonPropertyName("codigo")]
        public string? Codigo { get; set; }

        [JsonPropertyName("descricao")]
        public string? Descricao { get; set; }

        [JsonPropertyName("unidade")]
        public string? Unidade { get; set; }

        [JsonPropertyName("ncm")]
        public string? Ncm { get; set; }
    }
}
