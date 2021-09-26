using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PokemonRepo.Domain;
using PokemonRepo.Domain.DbModels;
using PokemonRepo.DTO;
using PokemonRepo.DTO.DbModels;

namespace PokemonRepo.UI.Pages.FightingCage
{
    public class ThisChatroomModel : PageModel
    {
        private readonly DbHandler _dbhandler;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DatabaseContext _dbContext;

        public ApplicationUser AppUser { get; set; }

        [BindProperty]
        public ChatRoom ThisChatroom { get; set; }
        [BindProperty]
        public List<ChatMessage> Messages { get; set; }
        [BindProperty]
        public string ThisMessage { get; set; }
        [BindProperty]
        public int ChatRoomid { get; set; }
        [BindProperty]
        public int ChatMessageid { get; set; }

        public bool IsEditMode { get; set; }

        public ThisChatroomModel(DbHandler dbhandler, UserManager<ApplicationUser> userManager, DatabaseContext dbContext)
        {
            _dbhandler = dbhandler;
            _userManager = userManager;
            _dbContext = dbContext;
        }
        public async Task OnGet(int id, bool isEdit = false, int chatMessageId = 0)
        {
            IsEditMode = isEdit;
            ChatMessageid = chatMessageId;
            Messages = await _dbhandler.GetAllChatMessages(id);
            Messages = Messages.OrderByDescending(m => m.Date).ToList();
            ThisChatroom = await _dbhandler.GetChatRoom(id);
            AppUser = await _userManager.GetUserAsync(User);
        }
        public async Task<IActionResult> OnPost()
        {
            var message = new ChatMessage()
            {
                Message = ThisMessage,
                User = await _userManager.GetUserAsync(HttpContext.User),
                ChatRoom = await _dbhandler.GetChatRoom(ChatRoomid),
                Date = DateTime.Now
            };
            
            await _dbhandler.AddMessage(message);

            return RedirectToPage("ThisChatroom", new { id = ChatRoomid });
        }
        public async Task<IActionResult> OnPostDelete()
        {
            await _dbhandler.DelteMessage(ChatMessageid);
            return RedirectToPage("ThisChatRoom", new { id = ChatRoomid });
        }

        public async Task<IActionResult> OnPostEdit()
        {            
            return RedirectToPage("ThisChatRoom", new { id = ChatRoomid, isEdit = true, chatMessageId = ChatMessageid});
        }
        public async Task<IActionResult> OnPostDoneEdit()
        {
            var chatmessage = await _dbContext.ChatMessages.FirstOrDefaultAsync(c => c.ChatMessageId == ChatMessageid);
            if(chatmessage != null && !String.IsNullOrEmpty(ThisMessage))
            {
                chatmessage.Message = ThisMessage;
                _dbContext.ChatMessages.Update(chatmessage);
                await _dbContext.SaveChangesAsync();
    
            }
            else if(String.IsNullOrEmpty(ThisMessage))
            {
               await _dbhandler.DelteMessage(ChatMessageid);
            }
            return RedirectToPage("ThisChatRoom", new { id = ChatRoomid });
        }
    }
}
