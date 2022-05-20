using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplicationInstituto.Dto;
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

        public async Task<OperationResult> CreateAlumno(Alumno alumno)
        {
            Uri uri = new Uri($"{_httpClient.BaseAddress}Alumno");

            var jsonInString = JsonConvert.SerializeObject(alumno);

            var response = await _httpClient.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            var result = new OperationResult();


            var a = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                result.IsSuccess = false;
                result.problemDetail = JsonConvert.DeserializeObject<ProblemDetail>(await response.Content.ReadAsStringAsync());
            }

            return result;

        }
    }
}
