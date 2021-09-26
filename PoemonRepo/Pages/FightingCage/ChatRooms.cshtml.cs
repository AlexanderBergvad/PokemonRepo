using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonRepo.Domain.DbModels;
using PokemonRepo.DTO.DbModels;

namespace PokemonRepo.UI.Pages.FightingCage
{
    public class ChatRoomsModel : PageModel
    {
        private readonly DbHandler _dbHandler;
        public List<ChatRoom> chatRooms { get; set; }

        public ChatRoomsModel(DbHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }
        public async Task OnGet()
        {
            chatRooms = await _dbHandler.GetAllChatRooms();
        }
    }
}
