using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationInstituto.ApiServices;
using WebApplicationInstituto.Models;

namespace WebApplicationInstituto.Pages.Alumnos
{
    public class EditModel : PageModel
    {
        private readonly IApiInstitutoClient _apiInstitutoClient;

        public EditModel(IApiInstitutoClient apiInstitutoClient)
        {
            _apiInstitutoClient = apiInstitutoClient;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var resultado = await _apiInstitutoClient.UpdateAlumno(Alumno);

            if (!resultado.IsSuccess)
            {
                foreach (string key in resultado.problemDetail.Errors.Keys)
                {
                    ModelState.AddModelError(string.Empty, resultado.problemDetail.Errors[key].FirstOrDefault());
                }

                return Page();
            }

            return RedirectToPage("./Index");
        }

    }
}
