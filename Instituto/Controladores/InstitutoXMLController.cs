using Instituto.Entidades;
using Instituto.Enums;
using Instituto.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                    Nombre = a.Elements().FirstOrDefault(a => a.Name == "Nombre").Value,
                    FechaNacimiento = DateTime.Parse(a.Elements().FirstOrDefault(a => a.Name == "FechaNacimiento").Value)
                })
                .ToList();

            return alumnos;
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

            var alumnos = this.GetAlumnos();

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

        public List<Alumno> GetAlumnos(long idMateria)
        {
            return this.GetMaterias().FirstOrDefault(m => m.Id == idMateria)?.Alumnos;
        }

        public List<Materia> GetMaterias(long idAlumno)
        {
            return this.GetMaterias().Where(m => m.Alumnos.Any(a => a.Id == idAlumno)).ToList();
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
