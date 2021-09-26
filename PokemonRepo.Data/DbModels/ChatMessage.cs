using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRepo.DTO.DbModels
{
    public class ChatMessage
    {
        public int ChatMessageId { get; set; }
        public virtual ChatRoom ChatRoom { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
