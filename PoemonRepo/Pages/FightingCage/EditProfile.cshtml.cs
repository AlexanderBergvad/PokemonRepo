using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PokemonRepo.Application;
using PokemonRepo.Data;
using PokemonRepo.Domain;
using PokemonRepo.DTO;

namespace PokemonRepo.UI.Pages.FightingCage
{
    public class EditProfileModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DatabaseContext _dbContext;

        public ApplicationUser ProfileUser { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Enter old password!")]
        public string Password { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Enter new or same password!")]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        public string NewPassword { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }
        [BindProperty]
        public string AboutMe { get; set; }
        [BindProperty]
        public string FavoritePok { get; set; }
        [BindProperty]
        public List<PokemonModel> Pokemons { get; set; }
        public List<PokemonModel> FavoritePokemons { get; set; }

        public List<string> pokemons { get; set; }



        public EditProfileModel( UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment, DatabaseContext dbContext)
        {
            pokemons = new List<string>();
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _dbContext = dbContext;
        }
        public async Task OnGet()
        {
            var pokemonNames = Enum.GetValues(typeof(PokemonNames)).Cast<PokemonNames>();
            foreach (var pokemon in pokemonNames)
            {
                pokemons.Add(pokemon.ToString().ToLower());
            }
            ProfileUser = await _userManager.GetUserAsync(User);
        }
        public async Task<IActionResult> OnPost()
        {
            ProfileUser = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            { 
                var result = await _userManager.ChangePasswordAsync(ProfileUser, Password, NewPassword);
                if(result.Succeeded)
                {

                    if (Photo != null)
                    {

                        // Create folder

                        string folder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }

                        // Delete existing photo
                        DeleteExistingPhoto(folder, ProfileUser);

                        // Upload new photo

                        string uniqueFileName = UploadNewPhoto(folder, ProfileUser);
                        ProfileUser.PhotoPath = uniqueFileName;
                    }
                    
                        // Update repo with new photopath
                        ProfileUser.UserName = Username;
                        ProfileUser.NormalizedUserName = Username;
                        ProfileUser.Email = Email;
                        ProfileUser.NormalizedEmail = Email;
                        ProfileUser.AboutMe = AboutMe;
                        ProfileUser.FavoritPokemon = FavoritePok;

                        _dbContext.Users.Update(ProfileUser);
                        await _dbContext.SaveChangesAsync();

                        return RedirectToPage("/FightingCage/MyProfile");
                }
                foreach(var errors in result.Errors)
                {
                    ModelState.AddModelError("", errors.Description);
                }
            }
              
            return Page();
        }

        private string UploadNewPhoto(string folder, ApplicationUser user)
        {
            string uniqueFileName = String.Concat(Guid.NewGuid().ToString(), "-",  user.UserName, ".jpg");

            string newFile = Path.Combine(folder, uniqueFileName);

            using (var fileStream = new FileStream(newFile, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }

            return uniqueFileName;
        }

        private void DeleteExistingPhoto(string folder, ApplicationUser user)
        {
            string oldFile = Path.Combine(folder, user.PhotoPath);

            if (System.IO.File.Exists(oldFile))
            {
                System.IO.File.Delete(oldFile);
            }
        }
    }
}
