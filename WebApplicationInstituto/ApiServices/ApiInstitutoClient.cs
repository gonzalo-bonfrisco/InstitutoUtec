using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplicationInstituto.Models;

namespace WebApplicationInstituto.ApiServices
{
    public class ApiInstitutoClient : IApiInstitutoClient
    {
        private readonly HttpClient _httpClient;

        public ApiInstitutoClient(IHttpClientFactory factory)
        {
            this._httpClient = factory.CreateClient("ApiInstitutoClient");

        }

        public async Task<List<Alumno>> GetAlumnos()
        {
            Uri uri = new Uri($"{_httpClient.BaseAddress}Alumno");

            var responseString = await _httpClient.GetStringAsync(uri);

            var alumnos = JsonConvert.DeserializeObject<List<Alumno>>(responseString);

            return alumnos;
        }
    }
}
