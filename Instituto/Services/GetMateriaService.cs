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
    public class GetMateriaService : IGetMateriaService
    {
        private readonly IXMLProvider provider;
        private readonly IGetAlumnoService getAlumnoService;

        public GetMateriaService(IXMLProvider provider, IGetAlumnoService getAlumnoService = null)
        {
            this.provider = provider;
            this.getAlumnoService = getAlumnoService;
        }

        public List<Materia> GetMaterias()
        {
            var document = provider.GetDocument(XMLEnum.Materias);

            var materias = document.Root.Elements()
                .Select(a => new Materia()
                {
                    Id = long.Parse(a.Elements().FirstOrDefault(a => a.Name == "Id").Value),
                    Nombre = a.Elements().FirstOrDefault(a => a.Name == "Nombre").Value,
                    AuxAlumnos = a.Elements().FirstOrDefault(a => a.Name == "Alumnos").Value
                })
                .ToList();

            var alumnos = this.getAlumnoService.GetAlumnos();

            materias.Where(mat => !string.IsNullOrEmpty(mat.AuxAlumnos))
                    .ToList()
                    .ForEach(mat =>
                    {
                        mat.AuxAlumnos.Split("|").ToList()
                            .ForEach(str =>
                            {
                                mat.Alumnos.Add(alumnos.FirstOrDefault(a => a.Id == long.Parse(str)));
                            });
                    });

            return materias;
        }
    }
}
