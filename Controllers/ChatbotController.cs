using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ChatbotAPI.Data;  // Βεβαιώσου ότι εισάγεις το DbContext
using ChatbotAPI.Models;  // Εισαγωγή του μοντέλου Message

namespace ChatbotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatbotController : ControllerBase
    {
        private readonly string _pythonScriptPath = @"C:\Users\v.kormazos\Desktop\Projects\ChatbotAPI\chat.py"; 

        private readonly ChatbotDbContext _context;

        public ChatbotController(ChatbotDbContext context)
        {
            _context = context;
        }

        [HttpPost("ask")]
        public IActionResult AskChatbot([FromBody] ChatRequest request)
        {
            var result = RunPythonScript(request.Question);

            // Αποθήκευση στη βάση δεδομένων
            var message = new Message
            {
                UserMessage = request.Question,
                BotResponse = result,
                Timestamp = DateTime.UtcNow
            };

            _context.Messages.Add(message);
            _context.SaveChanges(); // Αποθηκεύει την εγγραφή στη βάση

            return Ok(new { answer = result });
        }

        private string RunPythonScript(string question)
        {
            try
            {
                string pythonExePath = @"C:\Users\v.kormazos\AppData\Local\Programs\Python\Python313\python.exe";  

                var startInfo = new ProcessStartInfo
                {
                    FileName = pythonExePath,  
                    Arguments = _pythonScriptPath + " " + question,  
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(startInfo))
                using (var reader = process.StandardOutput)
                {
                    return reader.ReadToEnd();  
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }

    public class ChatRequest
    {
        public string Question { get; set; }
    }
}