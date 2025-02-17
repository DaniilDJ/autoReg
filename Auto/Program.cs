
using auto.browser.Configuration;
using auto.browser.Tests;
using auto.browser.webdriver;

namespace Auto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();https://git-fork.com/images/image1Win.jpg
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<WebBrowserOptions>(builder.Configuration.GetSection(WebBrowserOptions.Position));
            builder.Services.AddTransient<WebDriverFactory>();
            builder.Services.AddTransient<OpenRegistration>();
            builder.Services.AddTransient<RegisterAccount>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.Run();
        }
    }
}
