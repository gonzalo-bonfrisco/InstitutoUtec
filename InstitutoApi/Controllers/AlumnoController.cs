using InstitutoApi.Dto;
using InstitutoApi.Dto.Mappers;
using InstitutoApi.Modelo.Entidades;
using InstitutoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly ILogger<AlumnoController> _logger;

        private readonly IGetAlumnoService _getAlumnoService;
        private readonly IAlumnoMapper _alumnoMapper;
        private readonly IAlumnoService _alumnoService;

        public AlumnoController(IGetAlumnoService getAlumnoService, IAlumnoMapper alumnoMapper, IAlumnoService alumnoService, ILogger<AlumnoController> logger)
        {
            this._getAlumnoService = getAlumnoService;
            this._alumnoMapper = alumnoMapper;
            _alumnoService = alumnoService;
            _logger = logger;
        }

        /// <summary>
        /// Este metodo retorna la lista de todos los alumnos existentes en el sistema
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna lista de alumnos</response>
        [HttpGet]
        [Produces("application/json")]
        public async Task<List<AlumnoResponse>> Get()
        {
            var alumnos = await _getAlumnoService.GetAlumnos();
            return _alumnoMapper.MapToResponse(alumnos);

        }

        /// <summary>
        /// Obtiene un alumno por el identificador.
        /// </summary>
        /// <remarks>
        /// 
        /// Descripción: 
        /// 
        ///     Obtiene una alumno por su identificador.
        ///     
        /// </remarks>
        /// <param name="id" example="1">Código interno del alumno</param>
        /// <returns>Alumno encontrado a partir del identificador provisto</returns>
        /// <response code="200"></response>
        /// <response code="400">Error de validación.</response> 
        /// <response code="404">No encontrado.</response> 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlumnoResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var alumno = await _getAlumnoService.GetAlumno(id);

                if (alumno != null)
                    return Ok(_alumnoMapper.MapToResponse(alumno));

                return Problem(detail: $"No existe alumno con el id {id}"
                                , statusCode: StatusCodes.Status404NotFound
                                , title: "Error de validación");

            }
            catch (Exception ex)
            {
                // this._logger.LogError(ex, this.Url.ActionContext.ToString());

                return Problem("Problema interno.", "Get alumno por id", StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Crea un alumno a partir de los datos provistos
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="201"></response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AlumnoResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Create([FromBody] AlumnoRequest request)
        {
            try
            {

                var idAlumno = await _alumnoService.Createalumno(_alumnoMapper.MapToEntity(request));
                var response = _alumnoMapper.MapToResponse(await _getAlumnoService.GetAlumno(idAlumno));

                return Created(this.Url.Action("GetById", "Alumno", new { id = idAlumno }, Request.Scheme), response);

            }
            catch (Exception)
            {
                return Problem("Problema interno.", "Create alumno", StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        ///  Actualiza los datos de un alumno a partir de la información provista
        /// </summary>
        /// <param name="id"> Identificador interno del alumno</param>
        /// <param name="request"> Datos a actualizar del alumno</param>
        /// <returns> El alumno modificado.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlumnoResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Update(long id, [FromBody] AlumnoRequest request)
        {
            try
            {
                if (!await _alumnoService.AnyAlumno(id))
                    return Problem(detail: $"No existe alumno con el id {id}"
                                    , statusCode: StatusCodes.Status404NotFound
                                    , title: "Error de validación");

                var alumno = _alumnoMapper.MapToEntity(request);
                alumno.Id = id;

                await _alumnoService.UpdateAlumno(alumno);

                return Ok(_alumnoMapper.MapToResponse(await _getAlumnoService.GetAlumno(id)));
            }
            catch (Exception)
            {
                return Problem("Problema interno.", "update alumno", StatusCodes.Status500InternalServerError);
            }

        }

        /// <summary>
        ///  Remueve el alumno del sistema
        /// </summary>
        /// <param name="id"> Identificador interno del alumno</param>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlumnoResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Remove([Required(ErrorMessage = "Id requerido")] long id)
        {
            try
            {
                if (!await _alumnoService.AnyAlumno(id))
                    return Problem(detail: $"No existe alumno con el id {id}"
                                    , statusCode: StatusCodes.Status404NotFound
                                    , title: "Error de validación");

                await _alumnoService.RemoveAlumno(id);

                _logger.LogInformation($"Alumno: {id}, eliminado correctamente! ");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al remover alumno");
                return Problem("Problema interno.", "Remove alumno", StatusCodes.Status500InternalServerError);
            }

        }


    }
}
