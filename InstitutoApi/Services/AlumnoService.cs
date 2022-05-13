using InstitutoApi.Data;
using InstitutoApi.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task UpdateAlumno(Alumno alumno)
        {

            var entity = await _context.Alumnos.FirstOrDefaultAsync(s => s.Id == alumno.Id);

            entity.Nombre = alumno.Nombre;
            entity.FechaNacimiento = alumno.FechaNacimiento;

            await _context.SaveChangesAsync();

        }

        public async Task RemoveAlumno(long id)
        {
            var entity = await _context.Alumnos
                .FirstOrDefaultAsync(s => s.Id == id);

            _context.Alumnos.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAlumno(long id)
        {
            return await _context.Alumnos.AnyAsync(s => s.Id == id);
        }
    }
}
