using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UnipPim.Hotel.Extensions.DataAnnotations
{
    public class NomeCompletoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string nome = (value as string).ToLower();

                Regex regex = new Regex(@"^((\b[A-zÀ-ú']{2,40}\b)\s*){2,}$");

                if (regex.IsMatch(nome)) return ValidationResult.Success;

                return new ValidationResult("Nome completo é inválido");
            }

            return ValidationResult.Success;
        }
    }
}
