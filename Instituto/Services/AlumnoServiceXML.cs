using Instituto.Entidades;
using Instituto.Enums;
using Instituto.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Instituto.Services
{
    class AlumnoServiceXML : IAlumnoService
    {
        private readonly IXMLProvider provider;
        private readonly IGetMateriaService getMateriaService;
        private readonly IGetAlumnoService getAlumnoService;

        public AlumnoServiceXML(IXMLProvider provider, IGetMateriaService getMateriaService, IGetAlumnoService getAlumnoService)
        {
            this.provider = provider;
            this.getMateriaService = getMateriaService;
            this.getAlumnoService = getAlumnoService;
        }

        public void CreateAlumno(Alumno alumno)
        {
            var document = provider.GetDocument(XMLEnum.Alumnos);

            document.Root.Add(new XElement("Alumno",
                                   new XElement("Id", alumno.Id),
                                   new XElement("Nombre", alumno.Nombre),
                                   new XElement("FechaNacimiento", alumno.FechaNacimiento)
                             )
            );

            provider.SaveDocument(document, XMLEnum.Alumnos);
        }

        public List<Alumno> GetAlumnos()
        {
            return this.getAlumnoService.GetAlumnos();
        }

        public List<Alumno> GetAlumnos(long idMateria)
        {
            return this.getMateriaService.GetMaterias().FirstOrDefault(m => m.Id == idMateria)?.Alumnos;
        }

        public void RemoveAlumno(long id)
        {
            var document = provider.GetDocument(XMLEnum.Alumnos);

            document.Descendants("Alumno")
                .FirstOrDefault(a => a.Element("Id").Value == id.ToString())
                .Remove();

            provider.SaveDocument(document, XMLEnum.Alumnos);
        }

        public void UpdateAlumno(Alumno alumno)
        {
            var document = provider.GetDocument(XMLEnum.Alumnos);

            var alumnoModifificar = document.Descendants("Alumno")
                 .FirstOrDefault(a => a.Element("Id").Value == alumno.Id.ToString());

            alumnoModifificar.SetElementValue("Nombre", alumno.Nombre);
            alumnoModifificar.SetElementValue("FechaNacimiento", alumno.FechaNacimiento);

            provider.SaveDocument(document, XMLEnum.Alumnos);

        }
    }
}
