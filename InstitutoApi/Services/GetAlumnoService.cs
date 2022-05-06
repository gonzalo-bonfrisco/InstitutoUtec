using InstitutoApi.Data;
using InstitutoApi.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoApi.Services
{
    public class GetAlumnoService : IGetAlumnoService
    {
        private readonly InstitutoContext _context;

        public GetAlumnoService(InstitutoContext context)
        {
            _context = context;
        }

        public void Createalumno(Alumno alumno)
        {
            _context.Alumnos.Add(alumno);
            _context.SaveChanges();
        }

        public List<Alumno> GetAlumnos()
        {
            return _context.Alumnos.ToList();
        }
    }
}
