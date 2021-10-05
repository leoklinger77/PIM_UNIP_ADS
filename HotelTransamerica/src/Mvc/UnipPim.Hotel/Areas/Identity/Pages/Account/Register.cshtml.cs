using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Models.Enum;
using UnipPim.Hotel.Extensions.DataAnnotations;

namespace UnipPim.Hotel.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        private readonly IHospedeServico _hospedeServico;
        private readonly INotificacao _notificacao;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IHospedeServico hospedeServico,
            INotificacao notificacao)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _hospedeServico = hospedeServico;
            _notificacao = notificacao;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "E-mail")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirme a senha")]
            [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não correspondem.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório.")]
            [Display(Name = "Nome Completo")]
            [NomeCompleto]
            public string NomeCompleto { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório.")]
            [StringLength(11, ErrorMessage = "O campo {0} deve conter {1} números", MinimumLength = 11)]
            [Cpf]
            public string Cpf { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório.")]
            [Nascimento]
            public DateTime Nascimento { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório.")]
            [StringLength(11, ErrorMessage = "O campo {0} deve conter {1} números", MinimumLength = 11)]
            [Display(Name = "Telefone Celular")]
            [Celular]
            public string Celular { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (!await CadastrarHospede(user)) return Page();                   

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Por favor, confirme sua conta <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicando aqui</a>.");


                    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }


        private async Task<bool> CadastrarHospede(IdentityUser user)
        {

            var newHospede = new Hospede(Input.NomeCompleto, Input.Cpf, Input.Nascimento);
            newHospede.AddEmail(new Email(Input.Email, EmailTipo.PESSOAL));
            newHospede.AddTelefone(new Telefone(Input.Celular.Substring(0,2), Input.Celular.Substring(2), TelefoneTipo.CELULAR));

            await _hospedeServico.Insert(newHospede);

            if (_notificacao.ContemErros())
            {

                foreach (var item in _notificacao.Erros())
                {
                    ModelState.AddModelError(string.Empty, item);
                }

                await _userManager.DeleteAsync(user);

                return false;
            }

            return true;
        }
    }
}
