using InstitutoApi.Modelo.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoApi.Data
{
    public class InstitutoContext : DbContext
    {
        public InstitutoContext(DbContextOptions<InstitutoContext> options)
            : base(options)
        {
        }

        public DbSet<Alumno> Alumnos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
    }
}
