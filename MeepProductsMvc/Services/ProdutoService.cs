using MeepProductsMvc.Exceptions;
using MeepProductsMvc.Interfaces;
using MeepProductsMvc.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.Net;

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

        public async Task<ProdutosOmieTeste> PostOmieTeste(ProdutosOmieTeste produtosOmieTeste)
        {
            var cliente = new RestClient("https://app.omie.com.br/api/v1/geral/");
            
                        var param = new
                        {
                            codigo_produto_integracao = produtosOmieTeste.Param.Codigo_produto_integracao,
                            codigo = produtosOmieTeste.Param.Codigo,
                            descricao = produtosOmieTeste.Param.Descricao,
                            unidade = produtosOmieTeste.Param.Unidade,
                            ncm = produtosOmieTeste.Param.Ncm
                        };

                        var produto = new
                        {
                            call = produtosOmieTeste.Call,
                            app_key = produtosOmieTeste.App_key,
                            app_secret = produtosOmieTeste.App_secret,
                            param = new[] { param }
                        };
            
            var request = new RestRequest("produtos/", Method.Post);

            request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("Host", cliente.BaseUrl.Host, ParameterType.HttpHeader);
            request.AddJsonBody(produto);

            var response = await cliente.ExecuteAsync(request);

            var content = response.Content;

            Console.WriteLine(response.StatusCode);

            return null;
        }
    }

}