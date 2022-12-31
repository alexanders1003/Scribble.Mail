using Calabonga.AspNetCore.AppDefinitions;

namespace Scribble.Mail.Web.Definitions;

public class BaseDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });
        
        services.AddControllers();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
    }
}