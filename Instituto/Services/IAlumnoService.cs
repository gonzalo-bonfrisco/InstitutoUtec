using Instituto.Entidades;
using System.Collections.Generic;

namespace Instituto.Services
{
    internal interface IAlumnoService
    {
        List<Alumno> GetAlumnos();
        List<Alumno> GetAlumnos(long idMateria);
        void CreateAlumno(Alumno alumno);
        void RemoveAlumno(long id);
        void UpdateAlumno(Alumno alumno);
    }
}