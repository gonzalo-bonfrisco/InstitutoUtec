using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplicationInstituto.Handlers
{
    public interface IHttpApiClientHandler
    {
        Uri BaseAddress { get; set; }

        Task<string> GetStringAsync(Uri requestUri);
        Task<HttpResponseMessage> GetAsync(string requestUri);
        Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content);
        Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> DeleteAsync(string requestUri);
    }
}