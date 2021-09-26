using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonRepo.DTO;

namespace PokemonRepo.UI.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {

        readonly SignInManager<ApplicationUser> _signInManager;
        [BindProperty]
        [Required(ErrorMessage = "Missing username or dosent excist")]
        public string Username { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Wrong password or insert password.")]
        public string Password { get; set; }

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Username, Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/FightingCage/MyProfile");
                }
            }

            return Page();
        }
        public async Task<IActionResult> OnPostLogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToPage("/Login");
        }
    }
}
