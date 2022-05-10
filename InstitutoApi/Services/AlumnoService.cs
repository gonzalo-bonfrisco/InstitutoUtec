using InstitutoApi.Data;
using InstitutoApi.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoApi.Services
{
    public class AlumnoService : IAlumnoService
    {
        private readonly InstitutoContext _context;

        public AlumnoService(InstitutoContext context)
        {
            _context = context;
        }

        public async Task<long> Createalumno(Alumno alumno)
        {
            await _context.Alumnos.AddAsync(alumno);
            await _context.SaveChangesAsync();

            return alumno.Id;
        }
    }
}
