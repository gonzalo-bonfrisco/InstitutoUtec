using Instituto.Entidades;
using Instituto.Enums;
using Instituto.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto.Controladores
{
    public class InstitutoXMLController
    {
        private XMLProvider provider;

        public InstitutoXMLController()
        {
            provider = new XMLProvider();
        }

        public List<Alumno> GetAlumnos()
        {
            var document = provider.GetDocument(XMLEnum.Alumnos);

            var alumnos = document.Root.Elements()
                .Select(a => new Alumno()
                {
                    Id = long.Parse(a.Elements().FirstOrDefault(a => a.Name == "Id").Value),
                    Nombre = a.Elements().FirstOrDefault(a => a.Name == "Nombre").Value
                })
                .ToList();

            return alumnos;
        }
        public List<Materia> GetMaterias()
        {
            return null;
        }

        public List<Alumno> GetAlumnos(long idMateria)
        {
            return null; //Materias.FirstOrDefault(m => m.Id == idMateria).Alumnos;

        }

        public List<Materia> GetMaterias(long idAlumno)
        {
            return null;//Materias.Where(m => m.Alumnos.Any(a => a.Id == idAlumno)).ToList();
        }

    }
}
