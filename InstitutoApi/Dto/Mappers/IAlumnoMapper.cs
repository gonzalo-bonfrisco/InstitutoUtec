using InstitutoApi.Modelo.Entidades;
using System.Collections.Generic;

namespace InstitutoApi.Dto.Mappers
{
    public interface IAlumnoMapper
    {
        AlumnoResponse MapToResponse(Alumno alumno);
        List<AlumnoResponse> MapToResponse(List<Alumno> alumnos);
    }
}