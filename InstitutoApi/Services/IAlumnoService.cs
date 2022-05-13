using InstitutoApi.Modelo.Entidades;
using System.Threading.Tasks;

namespace InstitutoApi.Services
{
    public interface IAlumnoService
    {
        Task<long> Createalumno(Alumno alumno);
        Task UpdateAlumno(Alumno alumno);
        Task RemoveAlumno(long id);
        Task<bool> AnyAlumno(long id);
    }
}