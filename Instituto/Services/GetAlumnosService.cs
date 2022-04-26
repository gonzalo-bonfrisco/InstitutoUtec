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
    public class GetAlumnosService : IGetAlumnoService
    {
        private readonly IXMLProvider provider;

        public GetAlumnosService(IXMLProvider provider)
        {
            this.provider = provider;
        }

        public List<Alumno> GetAlumnos()
        {
            var document = provider.GetDocument(XMLEnum.Alumnos);

            var alumnos = document.Root.Elements()
                .Select(a => new Alumno()
                {
                    Id = long.Parse(a.Elements().FirstOrDefault(a => a.Name == "Id").Value),
                    Nombre = a.Elements().FirstOrDefault(a => a.Name == "Nombre").Value,
                    FechaNacimiento = DateTime.Parse(a.Elements().FirstOrDefault(a => a.Name == "FechaNacimiento").Value)
                })
                .ToList();

            return alumnos;
        }
    }
}
