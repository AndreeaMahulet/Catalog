using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Catalog.Data;
using Catalog.Models;

namespace Catalog.Pages.Tutors
{
    public class CreateModel : PageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public CreateModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tutore Tutore { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tutore.Add(Tutore);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
