using Instituto.Entidades;
using System.Collections.Generic;

namespace Instituto.Services
{
    public interface IMateriaService
    {
        List<Materia> GetMaterias();
        List<Materia> GetMaterias(long idAlumno);
    }
}