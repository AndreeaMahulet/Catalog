using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Catalog.Data;
using Catalog.Models;

namespace Catalog.Pages.Students
{
    public class EditModel : CourseCategoriesPageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public EditModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student = await _context.Student
              .Include(b => b.Tutore)
              .Include(b => b.CourseCategories).ThenInclude(b => b.Category)
              .AsNoTracking()
              .FirstOrDefaultAsync(m => m.ID == id);

            //Student = await _context.Student.FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Student);

            ViewData["TutoreID"] = new SelectList(_context.Set<Tutore>(), "ID", "NumeTutore");
            return Page();


        }
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studentToUpdate = await _context.Student
            .Include(i => i.Tutore)
            .Include(i => i.CourseCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (studentToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Student>(
            studentToUpdate,
            "Student",
            i => i.Nume, i => i.Prenume,
            i => i.An_studiu, i => i.FirstYear, i => i.TutoreID))
            {
                UpdateCourseCategories(_context, selectedCategories, studentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateCourseCategories(_context, selectedCategories, studentToUpdate);
            PopulateAssignedCategoryData(_context, studentToUpdate);
            return Page();
        }
    }
}


