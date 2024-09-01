
using MailKit.Net.Smtp;
using MimeKit;
using WebApi.Service.Models;

namespace WebApi.Service.Services
{
    //Denna klass är ansvarig för att skicka emails med hjälp av Smtp
    public class EmailService : IEmailService
    {
        // lagrar konfiguration om email så som smtp-server och port. Alltså det jag lagt i min appsettingjson. 
        private readonly EmailConfigurations _emailConfig;


        // Konstrktorn 
        public EmailService(EmailConfigurations emailConfig)
        {
            _emailConfig = emailConfig;
        }

        // Metod för att skicka mailet 
        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);

        }


        private MimeMessage CreateEmailMessage(Message message)
        {

            // Denna metod skapar ett MimeMessage som är ett objekt från klassen MimeMessagen
            // MimeMessage representerar hela epost-meddelandet. Som avsändare , Mottagare osv. 
            var emailMessage = new MimeMessage();

            // Avsändare 
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            // Mottagare - Eposten som tar emot mailen 
            emailMessage.To.AddRange(message.To);
            // Ämne 
            emailMessage.Subject = message.Subject;
            // Kroppen - innehållet i emailet 
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }


        private void Send(MimeMessage mailMessage)
        {

            // skapa en smtp client  - denna används för att kommunicera en stmp- server 
            using var client = new SmtpClient();

            try
            {
                // Connectar clienten. 
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);

                // Ta bort en autentiserings. Jag förstår det som att det har att göra med att vissa servrar inte stödjer detta. 
                client.AuthenticationMechanisms.Remove("XQAUTH2");


                // denna rad loggar in mig på servern. 
                client.Authenticate(_emailConfig.Username, _emailConfig.Password);


                // slutligen skicas mailet 
                client.Send(mailMessage);
            }
            catch
            {
                throw;
            }

            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
