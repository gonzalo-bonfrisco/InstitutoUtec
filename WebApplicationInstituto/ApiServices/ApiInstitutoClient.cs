using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApplicationInstituto.Dto;
using WebApplicationInstituto.Handlers;
using WebApplicationInstituto.Models;

namespace WebApplicationInstituto.ApiServices
{
    public class ApiInstitutoClient : IApiInstitutoClient
    {

        private readonly Uri _route;
        private readonly IHttpApiClientHandler _httpClient;

        public ApiInstitutoClient(IHttpApiClientHandler httpApiClientHandler, IApiSecurity apiSecurity)
        {
            this._httpClient = httpApiClientHandler;

            this._route = new Uri($"{_httpClient.BaseAddress}Alumno");
        }

        public async Task<List<Alumno>> GetAlumnos()
        {

            var responseString = await _httpClient.GetStringAsync(_route);

            var alumnos = JsonConvert.DeserializeObject<List<Alumno>>(responseString);

            return alumnos;
        }

        public async Task<Alumno> GetAlumno(long id)
        {

            var response = await _httpClient.GetAsync($"{ _route}/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            return JsonConvert.DeserializeObject<Alumno>(await response.Content.ReadAsStringAsync());

        }

        public async Task<OperationResult> CreateAlumno(Alumno alumno)
        {

            var jsonInString = JsonConvert.SerializeObject(alumno);

            var response = await _httpClient.PostAsync(_route, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            var result = new OperationResult();

            if (!response.IsSuccessStatusCode)
            {
                result.IsSuccess = false;
                result.problemDetail = JsonConvert.DeserializeObject<ProblemDetail>(await response.Content.ReadAsStringAsync());
            }

            return result;

        }

        public async Task<OperationResult> UpdateAlumno(Alumno alumno)
        {

            var jsonInString = JsonConvert.SerializeObject(alumno);

            var response = await _httpClient.PutAsync($"{ _route}/{alumno.Id}", new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            var result = new OperationResult();

            if (!response.IsSuccessStatusCode)
            {
                result.IsSuccess = false;
                result.problemDetail = JsonConvert.DeserializeObject<ProblemDetail>(await response.Content.ReadAsStringAsync());
            }

            return result;

        }

        public async Task<OperationResult> RemoveAlumno(long id)
        {
            var response = await _httpClient.DeleteAsync($"{ _route}/{id}");

            var result = new OperationResult();

            if (!response.IsSuccessStatusCode)
            {
                result.IsSuccess = false;
                result.problemDetail = JsonConvert.DeserializeObject<ProblemDetail>(await response.Content.ReadAsStringAsync());
            }

            return result;
        }

    }
}
