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

        private void LoadAlumnos()
        {
            Alumnos.Add(new Alumno() { Id = 1, Nombre = "Manolo Lamas", FechaNacimiento = new DateTime(1987, 01, 23) });
            Alumnos.Add(new Alumno()
            {
                Id = 2,
                Nombre = "Paco gonzalez",
                FechaNacimiento = new DateTime(1990, 07, 13)
            });
        }
        private void LoadMaterias()
        {
            Materias.Add(new Materia() { Id = 1, Nombre = "Física" });
            Materias.Add(new Materia() { Id = 2, Nombre = "Matemáticas" });
        }

    }
}
