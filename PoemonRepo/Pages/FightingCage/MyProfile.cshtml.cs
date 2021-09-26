using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonRepo.DTO;

namespace PokemonRepo.UI.Pages.FightingCage
{
    public class MyProfile : PageModel
    {

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public ApplicationUser ProfileUser { get; set; }
        public int counter { get; set; }
        public MyProfile(SignInManager<ApplicationUser> signOutManager, IWebHostEnvironment webHostEnvironment)
        {
            _signInManager = signOutManager;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task OnGet()
        {
           ProfileUser = await _signInManager.UserManager.GetUserAsync(User);
        }
    }
}
