using InstitutoApi.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoApi.Dto
{
    public class AlumnoRequest
    {
        /// <summary>
        /// Nombre del alumno
        /// </summary>
        /// <example>Juan del Castillo Vega</example>
        [Required(ErrorMessage = "El campo nombre no puede ser vacío")]
        public string Nombre { get; set; }

        /// <summary>
        /// Fecha de nacimiento del alumno
        /// </summary>
        [FechaNacimientoValidation]
        [Required(ErrorMessage = "El campo nombre no puede ser vacío")]
        public DateTime FechaNacimiento { get; set; }
    }
}
