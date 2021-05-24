using eStateV1.Areas.Identity.Pages.Account;
using eStateV1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eStateV1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Korisnik> _userManager;
        private readonly SignInManager<Korisnik> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public AccountController(SignInManager<Korisnik> signInManager,
            ILogger<LoginModel> logger,
            UserManager<Korisnik> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            InputModel input = new InputModel();

            input.Email=  Request.Form["Email"].ToString();
            input.Password = Request.Form["Password"].ToString();
            input.RememberMe = true;
            if(String.IsNullOrEmpty(Request.Form["ZapamtiMe"].ToString()))
            {
                input.RememberMe = false;
            }
            
            _logger.LogInformation("Vrijednost rem: " + input.RememberMe);


            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, isPersistent:input.RememberMe, lockoutOnFailure: false);
                _logger.LogInformation("Result logina: "+result.Succeeded);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }

            // If we got this far, something failed, redisplay form
            // _logger.LogInformation("Vrijednost rem: " + input.RememberMe);
            _logger.LogInformation("sto si ovdje");
            return RedirectToAction("Index","Home");
           
        }
    }
}
