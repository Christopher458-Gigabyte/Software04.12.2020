using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Software04._12._2020.Data;
using Software04._12._2020.Models;

namespace Software04._12._2020.Pages.Modules
{
    public class CreateModel : PageModel
    {
        private readonly Software04._12._2020.Data.Software04_12_2020Context _context;

        public CreateModel(Software04._12._2020.Data.Software04_12_2020Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Module Module { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Module.Add(Module);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
