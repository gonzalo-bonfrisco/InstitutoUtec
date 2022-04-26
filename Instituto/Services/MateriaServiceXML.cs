using Instituto.Entidades;
using Instituto.Enums;
using Instituto.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto.Services
{
    public class MateriaServiceXML : IMateriaService
    {

        private readonly IGetMateriaService getMateriaService;


        public MateriaServiceXML(IXMLProvider provider, IGetMateriaService getMateriaService, IGetAlumnoService getAlumnoService)
        {
            this.getMateriaService = getMateriaService;
        }

        public List<Materia> GetMaterias()
        {
            return this.getMateriaService.GetMaterias();
        }

        public List<Materia> GetMaterias(long idAlumno)
        {
            return this.GetMaterias().Where(m => m.Alumnos.Any(a => a.Id == idAlumno)).ToList();
        }
    }
}
