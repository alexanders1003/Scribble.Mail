using Calabonga.AspNetCore.AppDefinitions;
using MassTransit;
using Scribble.Mail.Web.Consumers;

namespace Scribble.Mail.Web.Definitions.MassTransit;

public class MassTransitDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddMassTransit(i =>
        {
            i.AddConsumer<MailMessageRequestConsumer, MailMessageRequestConsumerDefinition>();
            
            i.UsingRabbitMq((context, config) => 
                config.ConfigureEndpoints(context));
        });
    }
}