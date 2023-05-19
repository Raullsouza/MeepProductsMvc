using MeepProductsMvc.Exceptions;
using MeepProductsMvc.Interfaces;
using MeepProductsMvc.Models;
using Newtonsoft.Json;
using RestSharp;


namespace MeepProductsMvc.Services
{
    public class ProdutoService : IProdutoService
    {
        private const string apiEndpointMeep = "produto/";
        private const string apiEndpointOmie = "https://app.omie.com.br/api/v1/geral/";
        private readonly IHttpClientFactory _clientFactory;

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


        public async Task<ProdutosOmieTeste> PostOmieTeste()
        {
            var cliente = new RestClient("https://app.omie.com.br/api/v1/geral/");

            var produto = new
            {
                codigo_produto_integracao = "Bolsa",
                codigo = "bolsaNumero1",
                descricao = "PrimeiroProdutoIntegração",
                unidade = "UN",
                ncm = "22011000"
            };

            var produtosOmieTeste = new
            {
                call = "IncluirProduto",
                app_key = "3462853537143",
                app_secret = "fdac8f5ec5ae5643fd6ad01e5bc04b5c",
                param = new[] { produto }
            };

            var request = new RestRequest("produtos/", Method.Post);

            request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("Host", cliente.BaseUrl.Host, ParameterType.HttpHeader);
            request.AddJsonBody(produtosOmieTeste);

            var response = await cliente.ExecuteAsync(request);

            var content = response.Content;

            Console.WriteLine(response.StatusCode);

            return null;
        }




    }

}


