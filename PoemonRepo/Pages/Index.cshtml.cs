using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokemonRepo.Application;
using PokemonRepo.Data;
using PokemonRepo.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PoemonRepo.Pages
{
    public class IndexModel : PageModel
    {
        public readonly SignInManager<ApplicationUser> _signInManager;
        public ApplicationUser ProfileUser { get; set; }
        public IndexModel(SignInManager<ApplicationUser> signOutManager)
        {
            _signInManager = signOutManager;
        }
        public async Task OnGet()
        {
            ProfileUser = await _signInManager.UserManager.GetUserAsync(HttpContext.User);
        }
        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();

            return RedirectToPage("/Login");
        }
    }
}
