using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class AssignedCategoryData
    {
        public int CategoryID { get; set; }
        public string Nume { get; set; }
        public bool Assigned { get; set; }
    }
}
