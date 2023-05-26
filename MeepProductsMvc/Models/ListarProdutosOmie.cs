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

        [JsonPropertyName("pagina")]
        public int? Pagina { get; set; }

        [JsonPropertyName("total_de_paginas")]
        public int? Total_de_paginas { get; set; }

        [JsonPropertyName("registros")]
        public int? Registros { get; set; }

        [JsonPropertyName("total_de_registros")]
        public int? Total_de_registros { get; set; }

        [JsonPropertyName("produto_servico_resumido")]
        public List<ResponseContent>? Produto_servico_resumido { get; set; }
    }

    public class ResponseContent
    {
        [JsonPropertyName("codigo")]
        public string? Codigo { get; set; }

        [JsonPropertyName("codigo_produto")]
        public string? Codigo_produto { get; set; }

        [JsonPropertyName("codigo_produto_integracao")]
        public string? Codigo_produto_integracao { get; set; }

        [JsonPropertyName("descricao")]
        public string? Descricao { get; set; }

        [JsonPropertyName("valor_unitario")]
        public decimal? Valor_unitario { get; set; }
    }
}
 