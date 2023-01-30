using System.Net.Mail;

namespace Lahor.Shared.Services.Email
{
    public interface IEmail
    {
        Task Send(string subject, string body, string toAddress, Attachment attachment = null);
        Task Send(string subject, string body, string[] toAddresses, Attachment attachment = null);
    }
}