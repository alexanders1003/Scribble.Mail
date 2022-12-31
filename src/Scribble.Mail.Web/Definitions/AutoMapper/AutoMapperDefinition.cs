using Calabonga.AspNetCore.AppDefinitions;

namespace Scribble.Mail.Web.Definitions.AutoMapper;

public class AutoMapperDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddAutoMapper(typeof(Program));
    }
}