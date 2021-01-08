using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Catalog.Data;
using Catalog.Models;

namespace Catalog.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly Catalog.Data.CatalogContext _context;

        public IndexModel(Catalog.Data.CatalogContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }
        public StudentData StudentD{ get; set; }
        public int StudentID { get; set; }
        public int CategoryID { get; set; }


        public async Task OnGetAsync(int? id, int? categoryID)
        {
           StudentD = new StudentData();

            StudentD.Students = await _context.Student
            .Include(b => b.Tutore)
            .Include(b => b.CourseCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (id != null)
            {
                StudentID = id.Value;
                Student student = StudentD.Students
                .Where(i => i.ID == id.Value).Single();
                StudentD.Categories = student.CourseCategories.Select(s => s.Category);
            }
        }
    }
}
