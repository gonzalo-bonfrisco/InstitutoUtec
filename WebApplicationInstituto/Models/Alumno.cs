using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationInstituto.Models
{
    public class Alumno
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required, MaxLength(250)]
        public string Nombre { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
    }
}
