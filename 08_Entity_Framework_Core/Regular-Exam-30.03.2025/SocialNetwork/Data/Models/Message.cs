using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Content { get; set; } = null!;

        public DateTime SentAt { get; set; }

        public Status MessageStatus{ get; set; } 


        [ForeignKey(nameof(Conversation))]
        public int ConversationId { get; set; }
        public virtual Conversation Conversation { get; set; } = null!;


        [ForeignKey(nameof(Sender))]
        public int SenderId { get; set; }
        public virtual User Sender { get; set; } = null!;
    }
}

