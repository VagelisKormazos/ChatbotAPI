using Microsoft.EntityFrameworkCore;
using ChatbotAPI.Models;

namespace ChatbotAPI.Data
{
    public class ChatbotDbContext : DbContext
    {
        public ChatbotDbContext(DbContextOptions<ChatbotDbContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }
    }
}
