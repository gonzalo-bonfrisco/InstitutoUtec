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
    public class IndexModel : PageModel
    {
        private readonly IApiInstitutoClient _apiInstitutoClient;

        public IndexModel(IApiInstitutoClient apiInstitutoClient)
        {
            _apiInstitutoClient = apiInstitutoClient;
        }

        public IList<Alumno> Alumno { get; set; }

        public async Task OnGetAsync()
        {
            Alumno = await _apiInstitutoClient.GetAlumnos();
        }
    }
}
