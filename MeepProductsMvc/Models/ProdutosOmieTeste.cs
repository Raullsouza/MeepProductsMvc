using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace MeepProductsMvc.Models
{
    public class ParamObject
    {
        [JsonProperty(PropertyName = "codigo_produto_integracao")]
        public string? codigo_produto_integracao { get; set; }

        [JsonProperty(PropertyName = "codigo")]
        public string? codigo { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string? descricao { get; set; }

        [JsonProperty(PropertyName = "unidade")]
        public string? unidade { get; set; }

        [JsonProperty(PropertyName = "ncm")]
        public string? ncm { get; set; }
    }
    public class ProdutosOmieTeste
    {
        [JsonPropertyName("call")]
        public string? call { get; set; }

        [JsonPropertyName("app_key")]
        public string? authorizationKey { get; set; }

        [JsonPropertyName("app_secret")]
        public string? authorizationSecret { get; set; }

        [JsonPropertyName("param")]
        public ParamObject? param { get; set; }
    }
}
