using GarageRev.Data;
using GarageRev.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;

namespace GarageRev.Areas.Identity.Pages.Account {
    [AllowAnonymous]
    public class RegisterModel : PageModel {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        /// <summary>
        /// referência à BD do nosso sistema
        /// </summary>
        private readonly ApplicationDbContext _context;


        public RegisterModel(
            UserManager<IdentityUser> userManager,
            ILogger<RegisterModel> logger,
            ApplicationDbContext context) {
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Model usado para transportar os dados para a interface de 'Registar'
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        /// serve para redirecionar o utilizador para o 'local' de origem
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Classe usada para transportar/recolher os dados da Página para dentro do código
        /// </summary>
        public class InputModel {
            /// <summary>
            /// email que o user inseriu
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            /// password que o user inseriu
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            /// confirmação e comparação com a password que o user inseriu
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            /// <summary>
            /// ligação entre os Utilizadores e a tabela de Autenticação
            /// </summary>

            public string IdUtilizador { get; set; }
            /// <summary>
            /// Nome do Utilizador
            /// </summary>
            [Required(ErrorMessage = "Este campo é obrigatório!")]
            public string Nome { get; set; }
            /// <summary>
            /// Nacionalidade do Utilizador
            /// </summary>

            public string Nacionalidade { get; set; }
            /// <summary>
            /// Idade do Utilizador
            /// </summary>
            [Display(Name = "Data de Nascimento")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [DataType(DataType.Date)]
            public DateTime DataNascimento { get; set; }
        }

        /// <summary>
        /// Metodo a ser executado pela pagina, quando o HTTP é invocado em GET
        /// </summary>
        /// <param name="returnUrl"></param>

        public void OnGet(string returnUrl = null) {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null) {

            if (ModelState.IsValid) {
                var user = new IdentityUser {
                    UserName = Input.Email,
                    Email = Input.Email,
                    EmailConfirmed = false, // o email não está confirmado
                    LockoutEnabled = true // o utilizador pode ser bloqueado
                };
                //cria o user
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded) {
                    _logger.LogInformation("O utilizador criou uma nova conta com password.");




                    Utilizadores utilizador = new Utilizadores {
                        Email = user.Email,
                        IdUtilizador = user.Id,
                        Nome = Input.Nome,
                        Nacionalidade = Input.Nacionalidade,
                        //DataNascimento = Input.DataNascimento
                    };

                    //Verifica se o email colocado é do gestor e se for coloca essa conta como gestor, caso contrário colocado a conta como cliente
                    if (Input.Email == "admin@ipt.pt") {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else {
                        await _userManager.AddToRoleAsync(user, "Cliente");
                    }

                    try {
                        await _context.AddAsync(utilizador);
                        await _context.SaveChangesAsync(); // 'commit' da adição
                        //await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                        //return LocalRedirect(returnUrl);
                        // Enviar para o utilizador para a página de confirmação da criaçao de Registo
                        //return RedirectToPage("RegisterConfirmation");
                    }
                    catch (Exception) {
                        // avisar que houve um erro

                        ModelState.AddModelError("", "Ocorreu um erro na criação de dados");
                        // deverá ser apagada o User q foi previamente criador
                        await _userManager.DeleteAsync(user);

                        // devolver dados à pagina
                        return Page();
                    }
                }
                foreach (var error in result.Errors) {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

    }
}
