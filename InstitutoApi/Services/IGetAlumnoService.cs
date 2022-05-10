using InstitutoApi.Modelo.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstitutoApi.Services
{
    public interface IGetAlumnoService
    {
        Task<List<Alumno>> GetAlumnos();
        Task<Alumno> GetAlumno(long id);

    }
}