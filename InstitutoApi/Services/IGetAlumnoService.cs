using InstitutoApi.Modelo.Entidades;
using System.Collections.Generic;

namespace InstitutoApi.Services
{
    public interface IGetAlumnoService
    {
        List<Alumno> GetAlumnos();
    }
}