using System.Linq;
using System.Text.RegularExpressions;

namespace UnipPim.Hotel.Dominio.Tools
{
    public static class ExtensionsMethods
    {
		public static string SomenteNumeros(this string srt, string input)
		{
			return new string(input.Where(char.IsDigit).ToArray());
		}
		public static bool CpfValido(this string cpf)
		{
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			cpf = cpf.SomenteNumeros(cpf);
			if (cpf.Length != 11)
				return false;

			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;

			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}
		public static bool EmailValido(this string email)
		{
			var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
			return regexEmail.IsMatch(email);
		}
		public static bool ValidaTipoEnum<T>(int value)
        {
			return System.Enum.IsDefined(typeof(T), value);
        }
	}
}

