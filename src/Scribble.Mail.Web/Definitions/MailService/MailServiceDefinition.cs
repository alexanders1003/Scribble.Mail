using Calabonga.AspNetCore.AppDefinitions;

namespace Scribble.Mail.Web.Definitions.MailService;

public class MailServiceDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.Configure<MailSenderConfiguration>(
            builder.Configuration.GetSection("MailConfiguration"));
        
        builder.Services.AddTransient<IMailMessageSender, MailMessageSender>();
        builder.Services.AddTransient<IMailMessageFactory, MailMessageFactory>();
    }
}