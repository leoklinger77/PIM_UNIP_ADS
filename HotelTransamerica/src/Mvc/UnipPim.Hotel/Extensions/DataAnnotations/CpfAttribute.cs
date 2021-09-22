using System.ComponentModel.DataAnnotations;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Extensions.DataAnnotations
{
    public class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string cpf = (value as string).ToLower();

                if (cpf.CpfValido()) return ValidationResult.Success;

                return new ValidationResult("Cpf é inválido");
            }

            return ValidationResult.Success;
        }
    }
}
