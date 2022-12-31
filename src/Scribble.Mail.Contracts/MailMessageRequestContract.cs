using MimeKit;
using MimeKit.Text;

namespace Scribble.Mail.Contracts;

public class MailMessageRequestContract
{
    public string Recipient { get; init; } = null!;
    public string Subject { get; init; } = null!;
    public string Message { get; init; } = null!;
    public TextFormat Format { get; init; }
}