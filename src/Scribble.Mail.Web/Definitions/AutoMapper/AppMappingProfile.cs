using AutoMapper;
using Scribble.Mail.Contracts;
using Scribble.Mail.Web.Models;

namespace Scribble.Mail.Web.Definitions.AutoMapper;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<MailMessageRequestContract, MailMessageRequest>();
        CreateMap<MailMessageResponse, MailMessageResponseContract>();
    }
}