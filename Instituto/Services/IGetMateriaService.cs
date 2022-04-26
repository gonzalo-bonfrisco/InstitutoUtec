using Instituto.Entidades;
using System.Collections.Generic;

namespace Instituto.Services
{
    public interface IGetMateriaService
    {
        List<Materia> GetMaterias();
    }
}