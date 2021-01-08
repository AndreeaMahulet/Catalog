using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Catalog.Data;

namespace Catalog.Models
{
    public class CourseCategoriesPageModel : PageModel
    {
         
 public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(CatalogContext context,
        Student student)
        {
            var allCategories = context.Category;
            var courseCategories = new HashSet<int>(
            student.CourseCategories.Select(c => c.StudentID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Assigned = courseCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateCourseCategories(CatalogContext context,
        string[] selectedCategories, Student studentToUpdate)
        {
            if (selectedCategories == null)
            {
                studentToUpdate.CourseCategories = new List<CourseCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var courseCategories = new HashSet<int>
            (studentToUpdate.CourseCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!courseCategories.Contains(cat.ID))
                    {
                        studentToUpdate.CourseCategories.Add(
                        new CourseCategory
                        {
                            StudentID = studentToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (courseCategories.Contains(cat.ID))
                    {
                        CourseCategory courseToRemove
                        = studentToUpdate
                        .CourseCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    
}
}
