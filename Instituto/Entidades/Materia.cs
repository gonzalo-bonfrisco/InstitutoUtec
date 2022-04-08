using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto.Entidades
{
    public class Materia
    {
        public long Id { get; set; }
        public string Nombre { get; set; }

        public string AuxAlumnos { get; set; }
        public List<Alumno> Alumnos { get; set; }

        public Materia()
        {
            Alumnos = new List<Alumno>();
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.Nombre} ";
        }
    }
}
