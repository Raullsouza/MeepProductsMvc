using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MeepProductsMvc.Models
{
    public class ListarProdutosOmie
    {
        [JsonProperty(PropertyName = "pagina")]
        public string? Pagina { get; set; }

        [JsonProperty(PropertyName = "registros_por_pagina")]
        public string? Registros_por_pagina { get; set; }

        [JsonProperty(PropertyName = "filtrar_apenas_omiepdv")]
        public string? Filtrar_apenas_omiepdv { get; set; }
    }

    public class Authorization
    {
        [JsonPropertyName("call")]
        public string? Call { get; set; }

        [JsonPropertyName("app_key")]
        public string? App_key { get; set; }

        [JsonPropertyName("app_secret")]
        public string? App_secret { get; set; }

        [JsonPropertyName("param")]
        public ListarProdutosOmie? Param { get; set; }
    }
    public class ListarResponse
    {
        public int pagina { get; set; }
        public int total_de_paginas { get; set; }
        public int registros { get; set; }
        public int total_de_registros { get; set; }
        public List<ResponseContent> produto_servico_resumido { get; set; }
    }

    public class ResponseContent
    {
        public string codigo { get; set; }
        public string codigo_produto { get; set; }
        public string codigo_produto_integracao { get; set; }
        public string descricao { get; set; }
        public decimal valor_unitario { get; set; }
    }
}
 