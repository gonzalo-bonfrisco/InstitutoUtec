using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApplicationInstituto.ApiServices;

namespace WebApplicationInstituto.Handlers
{
    public class HttpApiClientHandler : IHttpApiClientHandler
    {
        private readonly HttpClient _httpClient;
        private readonly IApiSecurity _apiSecurity;
        public Uri BaseAddress { get; set; }

        public HttpApiClientHandler(IHttpClientFactory factory, IApiSecurity apiSecurity)
        {
            this._httpClient = factory.CreateClient("ApiInstitutoClient");
            _apiSecurity = apiSecurity;
            this.BaseAddress = _httpClient.BaseAddress;
        }



        public async Task<string> GetStringAsync(Uri requestUri)
        {
            var token = await _apiSecurity.GetToken();

            _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.token);

            return await _httpClient.GetStringAsync(requestUri);
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            var token = await _apiSecurity.GetToken();

            _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.token);

            return await _httpClient.GetAsync(requestUri);
        }

        public async Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            var token = await _apiSecurity.GetToken();

            _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.token);

            return await _httpClient.PostAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
        {
            var token = await _apiSecurity.GetToken();

            _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.token);

            return await _httpClient.PutAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            var token = await _apiSecurity.GetToken();

            _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.token);

            return await _httpClient.DeleteAsync(requestUri);
        }
    }
}
