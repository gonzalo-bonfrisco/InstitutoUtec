using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoApi.Dto
{
    public class AlumnoResponse
    {
        public long Id { get; set; }
        /// <summary>
        /// Nombre del alumno
        /// </summary>
        /// <example>Juan del Castillo Vega</example>
        public string Nombre { get; set; }
        /// <summary>
        /// Fecha de nacimiento del alumno
        /// </summary>
        public DateTime FechaNacimiento { get; set; }
    }
}
