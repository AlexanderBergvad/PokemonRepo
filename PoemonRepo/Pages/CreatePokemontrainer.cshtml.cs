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
    public class CreatePokemontrainerModel : PageModel
    {
        [BindProperty]
        public ControllUserModel ControlUser { get; set; }

        private readonly SignInManager<ApplicationUser> _signInManager;

        public CreatePokemontrainerModel( SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = ControlUser.Username,
                    Email = ControlUser.Email,
                    PhotoPath = "Default.png",
                    JoinedDate = DateTime.Now,
                    AboutMe = "Who am I? Write Something!",
                    FavoritPokemon = "I dont know yet."

                };

                var result = await _signInManager.UserManager.CreateAsync(user, ControlUser.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToPage("/FightingCage/MyProfile");
                }

                foreach(var errors in result.Errors)
                {
                    ModelState.AddModelError("", errors.Description);
                }
            }
            return Page();
        }
    }
}
