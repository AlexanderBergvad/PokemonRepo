using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonRepo.Domain;
using PokemonRepo.Domain.DbModels;
using PokemonRepo.DTO;
using PokemonRepo.DTO.DbModels;

namespace PokemonRepo.UI.Pages.FightingCage
{
    public class CreateChatroomModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DbHandler _dbHandler;
        public ChatRoom Chatroom { get; set; }

        [BindProperty]
        [Required]
        public string ChatRoomName { get; set; }

        [BindProperty]
        [Required]
        public string ChatRoomDescription { get; set; }
        public CreateChatroomModel(UserManager<ApplicationUser> userManager, DbHandler dbHandler )
        {
            _userManager = userManager;
            _dbHandler = dbHandler;
        }
        public void OnGet()
        {
          
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var chatroom = new ChatRoom()
                {
                    ChatRoomName = ChatRoomName,
                    Description = ChatRoomDescription,
                    Owner = user,

                };

                var result = await _dbHandler.AddChatRoom(chatroom);
                if (result)
                {
                    return RedirectToPage("/FightingCage/ChatRooms");
                }

            }
            return Page();
        }
    }
}
