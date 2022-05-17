using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using WebApplicationInstituto.Models;

namespace WebApplicationInstituto.Pages.Alumnos
{
    public class EditModel : PageModel
    {
        //private readonly WebApplicationInstituto.Data.WebApplicationInstitutoContext _context;

        public EditModel()
        {
            //_context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // _context.Attach(Alumno).State = EntityState.Modified;

            try
            {
                // await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoExists(Alumno.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AlumnoExists(long id)
        {
            return true;
            // return _context.Alumno.Any(e => e.Id == id);
        }
    }
}
