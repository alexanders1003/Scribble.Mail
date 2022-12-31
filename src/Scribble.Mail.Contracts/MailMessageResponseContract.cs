using MimeKit;

namespace Scribble.Mail.Contracts;

public class MailMessageResponseContract
{
    public string MessageId { get; init; } = null!;
    public IList<string> ErrorMessages { get; init; } = null!;

    public bool Succeeded => ErrorMessages.Count == 0;
}