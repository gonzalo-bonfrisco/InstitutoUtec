using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoApi.Modelo.Entidades
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
