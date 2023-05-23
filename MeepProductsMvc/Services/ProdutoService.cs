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


        public async Task<IEnumerable<ProdutosOmieTeste>> GetProdutos()
        {
            var client = _clientFactory.CreateClient("MeepProducts");
            HttpResponseMessage response = await client.GetAsync(apiEndpointMeep);
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var produtosVM = JsonConvert.DeserializeObject<IEnumerable<ProdutosOmieTeste>>(apiResponse);
                    return produtosVM;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<ListarResponse> ListarProdutos()
        {
            var client = new RestClient(apiEndpointOmie);

            var body = new
            {
                pagina = 1,
                registros_por_pagina = 50,
                filtrar_apenas_omiepdv = "N"
            };

            var authorization = new
            {
                call = "ListarProdutosResumido",
                app_key = "3462853537143",
                app_secret = "fdac8f5ec5ae5643fd6ad01e5bc04b5c",
                param = new[] { body }
            };

            var request = new RestRequest("produtos/", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(authorization);

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = response.Content;
                var responseObject = JsonConvert.DeserializeObject<ListarResponse>(content);
                return responseObject;
            }
            else
            {
                throw new OmieException("Erro ao enviar a solicitação para a API Omie.");
            }
        }


        public async Task<ProdutosOmieTeste> PostOmieTeste(ProdutosOmieTeste produtosOmieTeste)
        {
            var cliente = new RestClient(apiEndpointOmie);
            
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
  
            request.AddJsonBody(produto);

            var response = await cliente.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = response.Content;
                var responseObject = JsonConvert.DeserializeObject<ProdutosOmieTeste>(content);
                return null;
            }
            else
            {
                throw new OmieException("Erro ao enviar a solicitação para a API Omie.");
            }       
        }
    }

}