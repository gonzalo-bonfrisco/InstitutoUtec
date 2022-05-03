using InstitutoApi.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoApi.Services
{
    public class GetAlumnoService : IGetAlumnoService
    {
        public List<Alumno> GetAlumnos()
        {
            return new List<Alumno>() {
                new Alumno() {
                    Id = 1,
                    FechaNacimiento = DateTime.Now,
                    Nombre = "Manolo"
                },
                new Alumno() {
                    Id = 2,
                    FechaNacimiento = DateTime.Now,
                    Nombre = "Ana"
                }
            };
        }
    }
}
