using Instituto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Instituto.Controladores
{
    public class InstitutoController
    {
        private List<Alumno> Alumnos;
        private List<Materia> Materias;

        public InstitutoController()
        {

            Alumnos = new List<Alumno>();
            Materias = new List<Materia>();

            LoadAlumnos();
            LoadMaterias();
        }

        public List<Alumno> GetAlumnos()
        {
            return this.Alumnos;
        }
        public List<Materia> GetMaterias()
        {
            return this.Materias;
        }

        public List<Alumno> GetAlumnos(long idMateria)
        {
            return Materias.FirstOrDefault(m => m.Id == idMateria).Alumnos;

            #region CodigoComentado
            // return Materias.Where(m => m.Id == idMateria).Select(s=> s.Insciptos).FirstOrDefault();

            //var alumnos = new List<Alumno>();

            //foreach (Materia m in Materias)
            //{
            //    if (m.Id == idMateria)
            //    {
            //        alumnos = m.Insciptos;
            //    }
            //}
            //return alumnos;
            #endregion
        }

        public List<Materia> GetMaterias(long idAlumno)
        {
            // var alumno = Alumnos.FirstOrDefault(a => a.Id == idAlumno);
            //return Materias.Where(m => m.Alumnos.Contains(alumno)).ToList();

            return Materias.Where(m => m.Alumnos.Any(a => a.Id == idAlumno)).ToList();

        }

        private void LoadAlumnos()
        {
            Alumnos.Add(new Alumno() { Id = 1, Nombre = "Manolo Lamas", FechaNacimiento = new DateTime(1987, 01, 23) });
            Alumnos.Add(new Alumno()
            {
                Id = 2,
                Nombre = "Paco gonzalez",
                FechaNacimiento = new DateTime(1990, 07, 13)
            });
            Alumnos.Add(new Alumno()
            {
                Id = 3,
                Nombre = "Ana Perez",
                FechaNacimiento = new DateTime(1992, 06, 03)
            });
        }
        private void LoadMaterias()
        {
            Materias.Add(new Materia()
            {
                Id = 1,
                Nombre = "Física",
                Alumnos = { Alumnos[0], Alumnos[1] }
            });
            Materias.Add(new Materia()
            {
                Id = 2,
                Nombre = "Matemáticas",
                Alumnos = { Alumnos[1], Alumnos[2] }
            });
        }

    }
}
