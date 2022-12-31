using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Moq;
using RazorLight;
using Scribble.Mail.Web;
using Scribble.Mail.Web.Models;
using Xunit;

namespace Scribble.Mail.Tests;

public class MailMessageSenderTest
{
    [Fact]
    public async Task SendAsync_WhenRequestIsValid_SuccessfulSending()
    {
        var logger = new Mock<ILogger<MailMessageSender>>();
        
        IOptions<MailSenderConfiguration> config = Options.Create(new MailSenderConfiguration
        {
            Host = "smtp.mail.ru",
            Port = 465,
            SenderName = "Scribble Administration",
            SenderAddress = "no-reply.scribble@mail.ru",
            Password = "yRvzGg2pg2EvbKmCxNcg",
            UseSsl = true
        });

        var sender = new MailMessageSender(config, logger.Object, new MailMessageFactory());

        var result = await sender.SendAsync(new MailMessageRequest
        {
            Recipient = "alexander.sentsov03@gmail.com",
            Subject = "Test",
            Message = "<h1>This is test method</h1>",
            Format = TextFormat.Html
        });
        
        Assert.True(result.Succeeded);
    }
}