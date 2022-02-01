using Projekat.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Models
{
    public class CommissionConfirmationDto : IValidatableObject
    {
        public Guid CommissionId { get; set; }

        public Person President { get; set; }

        public List<Person> Members { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (President == null)
            {
                yield return new ValidationResult("Mora biti dodeljen predsednik", new[] { "PersonCreationDto" });
            }
        }
    }
}
