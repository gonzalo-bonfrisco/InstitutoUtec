using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationInstituto.Models;

namespace WebApplicationInstituto.ApiServices
{
    public interface IApiInstitutoClient
    {
        Task<List<Alumno>> GetAlumnos();
    }
}