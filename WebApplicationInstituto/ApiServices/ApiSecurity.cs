using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplicationInstituto.Dto;

namespace WebApplicationInstituto.ApiServices
{
    public class ApiSecurity : IApiSecurity
    {
        public IConfiguration Configuration { get; }
        private readonly HttpClient _httpClient;
        private readonly Uri _route;
        private APISecurityResponse _token;

        public ApiSecurity(IConfiguration configuration, IHttpClientFactory factory)
        {
            Configuration = configuration;
            this._httpClient = factory.CreateClient("ApiInstitutoClient");
            this._route = new Uri($"{_httpClient.BaseAddress}login");
        }

        public async Task<APISecurityResponse> GetToken()
        {
            if (_token == null || DateTime.UtcNow >= _token.expireAt)
                _token = await this.NewToken();

            return _token;

        }
        public async Task<APISecurityResponse> NewToken()
        {


            var user = new APIUser()
            {
                Username = Configuration["JWTClaims:Username"],
                Password = Configuration["JWTClaims:Password"]
            };


            var jsonInString = JsonConvert.SerializeObject(user);

            var response = await _httpClient.PostAsync(_route, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            var result = new OperationResult();

            if (!response.IsSuccessStatusCode)
            {
                return null;
                result.problemDetail = JsonConvert.DeserializeObject<ProblemDetail>(await response.Content.ReadAsStringAsync());
                // TODO agregar log de falla de obtencion de token
            }

            var token = JsonConvert.DeserializeObject<APISecurityResponse>(await response.Content.ReadAsStringAsync());

            return token;

        }



    }
}
