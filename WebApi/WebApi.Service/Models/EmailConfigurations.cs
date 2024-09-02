
using Org.BouncyCastle.Asn1.Crmf;

namespace WebApi.Service.Models
{
    public class EmailConfigurations
    {
        public string From { get; set; } = null!;
        public string SmtpServer { get; set; } = null!;
        public int Port { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!; 
    }
}
