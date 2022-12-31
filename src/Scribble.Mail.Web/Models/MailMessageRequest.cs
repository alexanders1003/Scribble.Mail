using MimeKit;
using MimeKit.Text;

namespace Scribble.Mail.Web.Models;

public class MailMessageRequest
{ 
    public string Recipient { get; init; } = null!;
    public string Subject { get; init; } = null!;
    public string Message { get; init; } = null!;
    public TextFormat Format { get; init; }
}