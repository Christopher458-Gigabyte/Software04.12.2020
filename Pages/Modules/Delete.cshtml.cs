using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Software04._12._2020.Data;
using Software04._12._2020.Models;

namespace Software04._12._2020.Pages.Modules
{
    public class DeleteModel : PageModel
    {
        private readonly Software04._12._2020.Data.Software04_12_2020Context _context;

        public DeleteModel(Software04._12._2020.Data.Software04_12_2020Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Module Module { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Module = await _context.Module.FirstOrDefaultAsync(m => m.ID == id);

            if (Module == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Module = await _context.Module.FindAsync(id);

            if (Module != null)
            {
                _context.Module.Remove(Module);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
