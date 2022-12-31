using MimeKit;
using MimeKit.Text;
using Scribble.Mail.Web.Models;

namespace Scribble.Mail.Web;

public interface IMailMessageFactory
{
    MimeMessage FromRequest(MailMessageRequest request, MailboxAddress sender);
}

public class MailMessageFactory : IMailMessageFactory
{
    public MimeMessage FromRequest(MailMessageRequest request, MailboxAddress sender)
    {
        var message = new MimeMessage();
        
        message.From.Add(sender);
        message.To.Add(new MailboxAddress(string.Empty, request.Recipient));

        message.Subject = request.Subject;
        message.Body = new TextPart(request.Format)
        {
            Text = request.Message
        };

        return message;
    }
}