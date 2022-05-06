using InstitutoApi.Dto;
using InstitutoApi.Dto.Mappers;
using InstitutoApi.Modelo.Entidades;
using InstitutoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IGetAlumnoService getAlumnoService;
        private readonly IAlumnoMapper alumnoMapper;

        public AlumnoController(IGetAlumnoService getAlumnoService, IAlumnoMapper alumnoMapper)
        {
            this.getAlumnoService = getAlumnoService;
            this.alumnoMapper = alumnoMapper;
        }

        /// <summary>
        /// Este metodo retorna la lista de todos los alumnos existentes en el sistema
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna lista de alumnos</response>
        [HttpGet]
        [Produces("application/json")]
        public List<AlumnoResponse> Get()
        {
            var alumnos = getAlumnoService.GetAlumnos();
            return alumnoMapper.MapToResponse(alumnos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AlumnoRequest request)
        {
            try
            {
                getAlumnoService.Createalumno(new Alumno()
                {
                    Nombre = "Prueba",
                    FechaNacimiento = DateTime.Now
                });

                return Created("pppp", 1);
            }
            catch (Exception)
            {
                return Problem("Problema interno.", "Create alumno", StatusCodes.Status500InternalServerError);
            }
        }

    }
}
