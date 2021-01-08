using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class StudentData
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<CourseCategory> CoursesCategories { get; set; }
    }
}
