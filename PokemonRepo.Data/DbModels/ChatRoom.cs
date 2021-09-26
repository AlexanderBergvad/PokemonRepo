using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRepo.DTO.DbModels
{
     public class ChatRoom
    {
        public int ChatRoomId { get; set; }
        public ApplicationUser Owner { get; set; }
        public string ChatRoomName { get; set; }
        public string Description { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }

    }
}
