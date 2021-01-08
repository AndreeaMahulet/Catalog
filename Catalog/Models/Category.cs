using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }
        public ICollection<CourseCategory> CourseCategories { get; set; }
    }
}
