using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonRepo.DTO;

namespace PokemonRepo.UI.Pages
{
    public class LogOutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogOutModel(SignInManager<ApplicationUser> signInManager)
        {
           _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();

            return RedirectToPage("/Login");
        }
       
    }
}
