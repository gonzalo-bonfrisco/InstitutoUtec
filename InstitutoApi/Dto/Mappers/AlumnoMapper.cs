using InstitutoApi.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoApi.Dto.Mappers
{
    public class AlumnoMapper : IAlumnoMapper
    {
        public AlumnoResponse MapToResponse(Alumno alumno)
        {
            return new AlumnoResponse()
            {
                Id = alumno.Id,
                Nombre = alumno.Nombre,
                FechaNacimiento = alumno.FechaNacimiento
            };
        }

        public List<AlumnoResponse> MapToResponse(List<Alumno> alumnos)
        {
            var response = new List<AlumnoResponse>();

            foreach (var alumno in alumnos)
            {
                response.Add(this.MapToResponse(alumno));
            }

            return response;
        }

        public Alumno MapToEntity(AlumnoRequest request)
        {
            return new Alumno()
            {
                Nombre = request.Nombre,
                FechaNacimiento = request.FechaNacimiento
            };
        }
    }
}
