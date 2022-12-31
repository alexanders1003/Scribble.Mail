using AutoMapper;
using MassTransit;
using MimeKit;
using Scribble.Mail.Contracts;
using Scribble.Mail.Web.Models;

namespace Scribble.Mail.Web.Consumers;

public class MailMessageRequestConsumer : IConsumer<MailMessageRequestContract>
{
    private readonly IMapper _mapper;
    private readonly IMailMessageSender _messageSender;

    public MailMessageRequestConsumer(IMapper mapper, IMailMessageSender messageSender)
    {
        _mapper = mapper;
        _messageSender = messageSender;
    }

    public async Task Consume(ConsumeContext<MailMessageRequestContract> context)
    {
        var request = _mapper.Map<MailMessageRequest>(context.Message);
        
        var response = await _messageSender
            .SendAsync(request, context.CancellationToken)
            .ConfigureAwait(false);

        var responseContract = _mapper.Map<MailMessageResponseContract>(response);
        
        await context.Publish(responseContract, context.CancellationToken)
            .ConfigureAwait(false);
    }
}

public class MailMessageRequestConsumerDefinition : ConsumerDefinition<MailMessageRequestConsumer>
{
    public MailMessageRequestConsumerDefinition()
    {
        EndpointName = "mail-service";
        ConcurrentMessageLimit = 8;
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<MailMessageRequestConsumer> consumerConfigurator)
    {
        endpointConfigurator.UseMessageRetry(i => i.Intervals(100, 200, 500, 800, 1000));
        endpointConfigurator.UseInMemoryOutbox();
    }
}