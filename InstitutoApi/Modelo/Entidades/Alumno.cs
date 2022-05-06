using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoApi.Modelo.Entidades
{
    public class Alumno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(250)]
        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public override string ToString()
        {
            return $"{this.Id} - {this.Nombre} - {this.FechaNacimiento}";
        }
    }
}
