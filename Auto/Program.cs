
using auto.browser.Configuration;
using auto.browser.webdriver;

namespace Auto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<WebBrowserOptions>(builder.Configuration.GetSection(WebBrowserOptions.Position));
            builder.Services.AddTransient<WebDriverFactory>();
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
            var factory = app.Services.GetRequiredService<WebDriverFactory>();
            var browser = factory.CreateDriver();
            browser.Navigate().GoToUrl("https://baltbet.ru/");
            app.Run();
        }
    }
}
