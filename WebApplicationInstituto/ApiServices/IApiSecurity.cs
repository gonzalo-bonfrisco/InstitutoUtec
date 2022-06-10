using System.Threading.Tasks;
using WebApplicationInstituto.Dto;

namespace WebApplicationInstituto.ApiServices
{
    public interface IApiSecurity
    {
        Task<APISecurityResponse> GetToken();
    }
}