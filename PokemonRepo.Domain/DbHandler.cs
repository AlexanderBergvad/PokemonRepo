using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PokemonRepo.DTO;
using PokemonRepo.DTO.DbModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRepo.Domain.DbModels
{
    public class DbHandler
    {
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly DatabaseContext _Context;

        public DbHandler(SignInManager<ApplicationUser> SignInManager, DatabaseContext Context)
        {
            _SignInManager = SignInManager;
            _Context = Context;
        }

        public async Task LogOut()
        {
            await _SignInManager.SignOutAsync();
        }

        public async Task<List<ChatRoom>> GetAllChatRooms()
        {
            return await _Context.ChatRooms.Include(c => c.Owner).ToListAsync();
        }

        public async Task<bool> AddChatRoom(ChatRoom chatRoom)
        {
            await _Context.AddAsync(chatRoom);
            var result = await _Context.SaveChangesAsync();
            if(result > 0)
            {
                return true;
            }
            return false;
            
        }

        public async Task<ChatRoom> GetChatRoom(int ChatRoomID)
        {
            return await _Context.ChatRooms.Include(c => c.Owner).FirstOrDefaultAsync(c => c.ChatRoomId == ChatRoomID);
        }

        public async Task<List<ChatMessage>> GetAllChatMessages(int ChatRoomId)
        {
            return await _Context.ChatMessages.Include(u => u.User).Where(cm => cm.ChatRoom.ChatRoomId == ChatRoomId).ToListAsync();
        }

        public async Task<bool> AddMessage(ChatMessage ChatMessage)
        {
            if(ChatMessage != null)
            {
                await _Context.ChatMessages.AddAsync(ChatMessage);
                return await _Context.SaveChangesAsync() > 0;
             }
            return false;
        }

        public async Task<bool> DelteMessage(int id)
        {
            var message = await _Context.ChatMessages.FirstOrDefaultAsync(c => c.ChatMessageId == id);
            if (message!= null)
            {
                _Context.ChatMessages.Remove(message);
                return await _Context.SaveChangesAsync() > 0;
            } 
            return false;
        }

    }
   
}
