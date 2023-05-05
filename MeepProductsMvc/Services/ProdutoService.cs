using MeepProductsMvc.Interfaces;
using MeepProductsMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MeepProductsMvc.Services
{
    public class ProdutoService : IProdutoService
    {
        private const string apiEndpointMeep = "produto/";
        private const string apiEndpointOmie = "produtos/";
        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientFactory _clientFactory;

        private ProdutoViewModel produtoVM;
        private IEnumerable<ProdutoViewModel> produtosVM;

        public ProdutoService( IHttpClientFactory clientFactory)
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetProdutos()
        {
            var client = _clientFactory.CreateClient("MeepProducts");
            HttpResponseMessage response = await client.GetAsync(apiEndpointMeep);
            {
                if( response.IsSuccessStatusCode )
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    produtosVM = await JsonSerializer.DeserializeAsync<IEnumerable<ProdutoViewModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
                return produtosVM;
            }
        }
     
        public async Task<ProdutoViewModel> GetProdutoById(int id)
        {
            var client = _clientFactory.CreateClient("MeepProducts");
            HttpResponseMessage response = await client.GetAsync(apiEndpointMeep + id);
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    produtoVM = await JsonSerializer.DeserializeAsync<ProdutoViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
                return produtoVM;
            }
        }
         
        public async Task<ProdutoOmie> PostOmie(ProdutoOmie produtoOmie)
        {
            var client = _clientFactory.CreateClient("OmieProducts");
            var produto = JsonSerializer.Serialize(produtoOmie);          
            StringContent content = new StringContent(produto, Encoding.UTF8, "application/json");


            HttpResponseMessage response = await client.PostAsync(apiEndpointOmie, content);
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    produtoOmie = await JsonSerializer
                          .DeserializeAsync<ProdutoOmie>
                          (apiResponse, _options);
                }
                else
                {
                    return null;
                }
                return produtoOmie;
            }
            
        }

        public async Task<ProdutoViewModel?> CriaProduto(ProdutoViewModel produtoVM)
        {
            var client = _clientFactory.CreateClient("MeepProducts");
            var produto = JsonSerializer.Serialize(produtoVM);
            StringContent content = new(produto, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(apiEndpointMeep, content);
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    produtoVM = await JsonSerializer
                        .DeserializeAsync<ProdutoViewModel>
                        (apiResponse, _options);
                }
                else
                {
                    return null;
                }
                return produtoVM;
            }
        }

        public async Task<bool> AtualizaProduto(int id, ProdutoViewModel produtoVM)
        {
            var client = _clientFactory.CreateClient("MeepProducts");
            HttpResponseMessage response = await client.PutAsJsonAsync(apiEndpointMeep + id, produtoVM);
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeletaProduto(int id)
        {
            var client = _clientFactory.CreateClient("MeepProducts");
            HttpResponseMessage response = await client.DeleteAsync(apiEndpointMeep + id);
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
