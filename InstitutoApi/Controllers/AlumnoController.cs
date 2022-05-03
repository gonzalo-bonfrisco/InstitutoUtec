using InstitutoApi.Dto;
using InstitutoApi.Dto.Mappers;
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

        [HttpGet]
        public List<AlumnoResponse> Get()
        {
            var alumnos = getAlumnoService.GetAlumnos();
            return alumnoMapper.MapToResponse(alumnos);
        }
    }
}
