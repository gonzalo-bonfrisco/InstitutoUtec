using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto.Entidades
{
    public class Alumno
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public override string ToString()
        {
            return $"{this.Id} - {this.Nombre} - {this.FechaNacimiento}";
        }
    }
}
