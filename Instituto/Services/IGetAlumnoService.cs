using Instituto.Entidades;
using System.Collections.Generic;

namespace Instituto.Services
{
    public interface IGetAlumnoService
    {
        List<Alumno> GetAlumnos();
    }
}