using MeepProductsMvc.Exceptions;
using MeepProductsMvc.Interfaces;
using MeepProductsMvc.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MeepProductsMvc.Services
{
    public class ProdutoService : IProdutoService
    {
        private const string apiEndpointMeep = "produto/";
        private const string apiEndpointOmie = "produtos/";
        private readonly IHttpClientFactory _clientFactory;
        //private ProdutoViewModel produtoVM;

        public ProdutoService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetProdutos()
                {
                    var client = _clientFactory.CreateClient("MeepProducts");
                    HttpResponseMessage response = await client.GetAsync(apiEndpointMeep);
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            var produtosVM = JsonConvert.DeserializeObject<IEnumerable<ProdutoViewModel>>(apiResponse);
                            return produtosVM;
                }
                        else
                        {
                            return null;
                        }             
                    }
                }
        

        /*         public async Task<ProdutoOmie> PostOmie(ProdutoOmie produtoOmie)
                 {
                     var client = _clientFactory.CreateClient("OmieProducts");
                     client.DefaultRequestHeaders.Accept.Clear();    
                     client.DefaultRequestHeaders.Add("accept", "* /*");
                     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                     var produto = JsonSerializer.Serialize(produtoOmie);
                     StringContent content = new(produto, Encoding.UTF8, "application/json");

                     HttpResponseMessage response = await client.PostAsync(apiEndpointOmie, content);
                     {
                         if (response.IsSuccessStatusCode)
                         {
                             var responseBody = await response.Content.ReadAsStreamAsync();
                             var apiResponse = await JsonSerializer.DeserializeAsync<ProdutoOmie>(responseBody, _options);
                         }
                         else
                         {
                             var errorMessage = await response.Content.ReadAsStringAsync();
                             throw new OmieException(response, errorMessage);
                         }
                         return produtoOmie;
                     }
                 }
             */

        public async Task<ParamObject> PostOmieTeste()
        {
            var produto = new
            {
                codigo_produto_integracao = "41ecferfrfgsdddf41",
                codigo = "4feferdssggegdess1",
                descricao = "Uncffdsfgsegtgrfdhda",
                unidade = "UN",
                ncm = "22011000"
            };

            var produtosOmieTeste = new
            {
                call = "IncluirProduto",
                app_key = "3436924896405",
                app_secret = "8d892811de34ad5a88034734467c74d6",
                param = new[] { produto }
            };

            var client = _clientFactory.CreateClient("OmieProducts");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("accept", "*/*");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(produtosOmieTeste);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsJsonAsync(apiEndpointOmie, content);

             if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ParamObject>(responseBody);
                return apiResponse;
            }
            else
            {
                  var errorMessage = await response.Content.ReadAsStringAsync();
                   throw new OmieException(response, errorMessage);     
            }
        }   
    }
}
