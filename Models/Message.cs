using System;
using System.ComponentModel.DataAnnotations;

namespace ChatbotAPI.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string UserMessage { get; set; }
        public string BotResponse { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

