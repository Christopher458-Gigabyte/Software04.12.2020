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
    public class IndexModel : PageModel
    {
        private readonly Software04._12._2020.Data.Software04_12_2020Context _context;

        public IndexModel(Software04._12._2020.Data.Software04_12_2020Context context)
        {
            _context = context;
        }

        public IList<Module> Module { get;set; }

        public async Task OnGetAsync()
        {
            Module = await _context.Module.ToListAsync();
        }
    }
}
