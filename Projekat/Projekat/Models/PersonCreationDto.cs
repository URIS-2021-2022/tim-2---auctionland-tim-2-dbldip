using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Models
{
    public class PersonCreationDto : IValidatableObject
    {
        public Guid PersonId { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti ime osobe.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti prezime osobe.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti ulogu osobe.")]
        public string Role { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Name == Surname)
            {
                yield return new ValidationResult("Osoba ne moze da ima isto ime i prezime", new[] { "PersonCreationDto" });
            }
        }
    }
}
