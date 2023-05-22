using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace MeepProductsMvc.Models
{
    public class ParamObject
    {
        [JsonProperty(PropertyName = "codigo_produto_integracao")]
        public string? Codigo_produto_integracao { get; set; }

        [JsonProperty(PropertyName = "codigo")]
        public string? Codigo { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string? Descricao { get; set; }

        [JsonProperty(PropertyName = "unidade")]
        public string? Unidade { get; set; }

        [JsonProperty(PropertyName = "ncm")]
        public string? Ncm { get; set; }
    }
    public class ProdutosOmieTeste
    {
        [JsonPropertyName("call")]
        public string? Call { get; set; }

        [JsonPropertyName("app_key")]
        public string? App_key { get; set; }

        [JsonPropertyName("app_secret")]
        public string? App_secret { get; set; }

        [JsonPropertyName("param")]
        public ParamObject? Param { get; set; }
    }
}
