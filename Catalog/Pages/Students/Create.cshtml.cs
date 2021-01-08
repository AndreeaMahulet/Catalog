using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Catalog.Data;
using Catalog.Models;

namespace Catalog.Pages.Students
{
    public class CreateModel :CourseCategoriesPageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public CreateModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TutoreID"] = new SelectList(_context.Set<Tutore>(), "ID", "NumeTutore");
            var student = new Student();
           student.CourseCategories = new List<CourseCategory>();
            PopulateAssignedCategoryData(_context, student);

            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newStudent = new Student();
            if (selectedCategories != null)
            {
                newStudent.CourseCategories = new List<CourseCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CourseCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newStudent.CourseCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Student>(
 newStudent,
 "Student",
            i => i.Nume, i => i.Prenume,
            i => i.An_studiu, i => i.FirstYear, i => i.TutoreID))
            {
                _context.Student.Add(newStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newStudent);
            return Page();
        }
    }

    
}
