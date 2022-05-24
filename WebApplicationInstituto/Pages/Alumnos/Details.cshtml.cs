using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationInstituto.ApiServices;
using WebApplicationInstituto.Models;

namespace WebApplicationInstituto.Pages.Alumnos
{
    public class DetailsModel : PageModel
    {
        private readonly IApiInstitutoClient _apiInstitutoClient;

        public DetailsModel(IApiInstitutoClient apiInstitutoClient)
        {
            _apiInstitutoClient = apiInstitutoClient;
        }

        public Alumno Alumno { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Alumno = await _apiInstitutoClient.GetAlumno((long)id);

            if (Alumno == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
