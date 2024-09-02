

using WebApi.Service.Models;

namespace WebApi.Service.Services
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
