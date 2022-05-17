using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using WebApplicationInstituto.Models;

namespace WebApplicationInstituto.Pages.Alumnos
{
    public class DetailsModel : PageModel
    {
        //private readonly WebApplicationInstituto.Data.WebApplicationInstitutoContext _context;

        public DetailsModel()
        {
            //_context = context;
        }

        public Alumno Alumno { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Alumno = null;// await _context.Alumno.FirstOrDefaultAsync(m => m.Id == id);

            if (Alumno == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
