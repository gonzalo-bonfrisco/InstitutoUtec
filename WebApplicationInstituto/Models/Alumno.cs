using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationInstituto.Models
{
    public class Alumno
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        // [MaxLength(250)]
        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}
