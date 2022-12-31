using MimeKit;

namespace Scribble.Mail.Web.Models;

public class MailMessageResponse
{
    public string MessageId { get; init; } = null!;
    public IList<string> ErrorMessages { get; init; } = null!;
    public bool Succeeded => ErrorMessages.Count == 0;

    public static MailMessageResponse Create(MimeMessage message, IList<string>? errorMessages = null!)
    {
        return new MailMessageResponse
        {
            MessageId = message.MessageId,
            ErrorMessages = errorMessages ?? new List<string>()
        };
    }
}