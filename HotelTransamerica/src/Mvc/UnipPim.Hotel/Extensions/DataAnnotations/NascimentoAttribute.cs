using System;
using System.ComponentModel.DataAnnotations;

namespace UnipPim.Hotel.Extensions.DataAnnotations
{
    public class NascimentoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {                
                DateTime nascimento = (DateTime)value;

                if (nascimento < DateTime.Now.AddYears(-16).Date) return ValidationResult.Success;

                return new ValidationResult("Nascimento é inválido, mínimo 16 anos.");
            }

            return ValidationResult.Success;
        }
    }
}
