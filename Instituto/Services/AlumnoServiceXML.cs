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

        public AlumnoServiceXML(IXMLProvider provider)
        {
            this.provider = provider;
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
            throw new NotImplementedException();
        }

        public List<Alumno> GetAlumnos(long idMateria)
        {
            throw new NotImplementedException();
        }

        public void RemoveAlumno(long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAlumno(Alumno alumno)
        {
            throw new NotImplementedException();
        }
    }
}
