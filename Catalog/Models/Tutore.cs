using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Catalog.Models
{
    public class Tutore
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage =
         "Numele tutorului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50,
MinimumLength = 3)]
        public string NumeTutore { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
