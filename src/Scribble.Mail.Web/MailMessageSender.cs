using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Scribble.Mail.Web.Models;

namespace Scribble.Mail.Web;

public interface IMailMessageSender
{
    Task<MailMessageResponse> SendAsync(MailMessageRequest messageRequest, CancellationToken? token = default);
}

public class MailMessageSender : IMailMessageSender
{
    private readonly IMailMessageFactory _messageFactory;
    private readonly MailSenderConfiguration _configuration;
    private readonly ILogger<MailMessageSender> _logger;

    public MailMessageSender(IOptions<MailSenderConfiguration> configuration, ILogger<MailMessageSender> logger, 
        IMailMessageFactory messageFactory)
    {
        _configuration = configuration.Value;
        _logger = logger;
        _messageFactory = messageFactory;
    }

    public async Task<MailMessageResponse> SendAsync(MailMessageRequest messageRequest, CancellationToken? token = default)
    {
        var message = _messageFactory.FromRequest(messageRequest, 
            new MailboxAddress(_configuration.SenderName, _configuration.SenderAddress));
        
        try
        {
            using var client = new SmtpClient();
            
            await client.ConnectAsync(_configuration.Host, _configuration.Port, _configuration.UseSsl)
                .ConfigureAwait(false);
            await client.AuthenticateAsync(_configuration.SenderAddress, _configuration.Password)
                .ConfigureAwait(false);
            await client.SendAsync(message)
                .ConfigureAwait(false);
            await client.DisconnectAsync(false)
                .ConfigureAwait(false);
            
            _logger.LogInformation("The message with id {MessageId} was sent successfully", message.MessageId);
            
            return MailMessageResponse.Create(message);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Some error occurred while sending the message");

            return MailMessageResponse.Create(message, new List<string>
            {
                exception.Message
            });
        }
    }
}