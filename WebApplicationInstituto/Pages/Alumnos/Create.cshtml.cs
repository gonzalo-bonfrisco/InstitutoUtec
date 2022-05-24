using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationInstituto.ApiServices;
using WebApplicationInstituto.Models;

namespace WebApplicationInstituto.Pages.Alumnos
{
    public class CreateModel : PageModel
    {
        private readonly IApiInstitutoClient _apiInstitutoClient;

        public CreateModel(IApiInstitutoClient apiInstitutoClient)
        {
            _apiInstitutoClient = apiInstitutoClient;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Alumno Alumno { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var resultado = await _apiInstitutoClient.CreateAlumno(Alumno);

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
