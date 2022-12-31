using Microsoft.AspNetCore.Mvc;
using Scribble.Mail.Web.Models;

namespace Scribble.Mail.Web.Controllers;

[ApiController]
[Route("api/mail")]
public class MailController : ControllerBase
{
    private readonly IMailMessageSender _messageSender;

    public MailController(IMailMessageSender messageSender) => 
        _messageSender = messageSender;

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<MailMessageResponse>> Post(MailMessageRequest request) =>
        await _messageSender
            .SendAsync(request, HttpContext.RequestAborted)
            .ConfigureAwait(false);
}