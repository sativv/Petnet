using MimeKit;

namespace WebApi.Service.Models
{
    public class Message
    {

        // Lista med Mailboxadress objekt. Om man ska skicka till flera användare
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; } = null!;

        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();

            // I denna nya lisan så lagras vår lista med strings. Men varje strings omvandlas till ett mailboxadress
            //objekt. Email blir namnet på varje Mailboxadress och stringen(x) blir adress
            To.AddRange(to.Select(x => new MailboxAddress("email",x)));
            Subject = subject;
            Content = content; 
        }
    }
}
