using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationInstituto.Dto;
using WebApplicationInstituto.Models;

namespace WebApplicationInstituto.ApiServices
{
    public interface IApiInstitutoClient
    {
        Task<List<Alumno>> GetAlumnos();
        Task<OperationResult> CreateAlumno(Alumno alumno);
        Task<Alumno> GetAlumno(long id);
        Task<OperationResult> RemoveAlumno(long id);
    }
}