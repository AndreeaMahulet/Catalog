using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Models
{
    public class Student
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage =
        "Numele trebuie sa inceapa cu litera mare"), Required, StringLength(50,
MinimumLength = 3)]
        public String Nume { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage =
        "Prenumele trebuie sa inceapa cu litera mare"), Required, StringLength(50,
MinimumLength = 3)]
        public String Prenume { get; set; }
        [Range(1, 3)]
        [Display(Name = "An studiu")]
        public int An_studiu { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "An Inscriere")]
        public DateTime FirstYear { get; set; }
        public int TutoreID { get; set; }
        public Tutore Tutore { get; set; }
        [Display(Name = "Tipul Cursului")]
        public ICollection<CourseCategory> CourseCategories { get; set; }
    }
}
