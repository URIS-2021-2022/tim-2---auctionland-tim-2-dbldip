using CommissionWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Models
{
    public class PersonUpdateDto : IValidatableObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public Guid CommissionId { get; set; }
        public Commission Commission { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Name == Surname)
                yield  return new ValidationResult("Nije moguce posedovati isto ime i prezime", new[] { "PersonCreationDto" });
        }
    }
}
