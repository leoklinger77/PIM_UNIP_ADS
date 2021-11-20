using System;
using System.ComponentModel.DataAnnotations;
using UnipPim.Hotel.Dominio.Tools;

namespace UnipPim.Hotel.Extensions.DataAnnotations
{
    public class CelularAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string numero = (value as string).ToLower();
                
                if (numero.NumeroTelefoneValido()) return ValidationResult.Success;

                return new ValidationResult("Celular é inválido");
            }

            return ValidationResult.Success;
        }
    }

    public class DataEntradaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime numero = (DateTime)value;
            
            if (DateTime.Now.Date <= numero) return ValidationResult.Success;
            
            return new ValidationResult("Celular é inválido");  
        }
    }

}
