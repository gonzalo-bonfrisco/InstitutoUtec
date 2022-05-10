using InstitutoApi.Data;
using InstitutoApi.Modelo.Entidades;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Alumno> GetAlumno(long id)
        {
            return await _context.Alumnos.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Alumno>> GetAlumnos()
        {
            return await _context.Alumnos.ToListAsync();
        }

    }
}
