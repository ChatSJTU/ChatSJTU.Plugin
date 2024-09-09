using ChatSJTU.Plugin.Services;
using ChatSJTU.Plugin.Log;

namespace ChatSJTU.Plugin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GlobalCookie.CookieContainer = new System.Net.CookieContainer();
            GlobalCookie.Read();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton(typeof(RequestResponseLoggingMiddleware));
            builder.WebHost.UseUrls("http://*:65472");

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                
            }

            app.UseAuthorization();

            app.UseRequestResponseLogging();

            app.MapControllers();

            app.Run();

            
        }
    }
}