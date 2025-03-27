using ChatbotAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=localhost;Database=ChatbotDB;User Id=sa;Password=1234vk!@;TrustServerCertificate=True;";
builder.Services.AddDbContext<ChatbotDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin() 
               .AllowAnyHeader()  
               .AllowAnyMethod(); 
    });
});
 

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAll");

app.Run();
